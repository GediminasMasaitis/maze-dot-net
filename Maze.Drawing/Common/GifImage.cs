using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Maze.Drawing.Common
{
    /// <summary>
    /// Uses default .net GIF encoding and adds animation headers.
    /// </summary>
    internal class GifImage 
    {
        #region Header Constants
        const byte FileTrailer = 0x3b;
        const byte ApplicationBlockSize = 0x0b;
        const byte GraphicControlExtensionBlockSize = 0x04;

        const int ApplicationExtensionBlockIdentifier = 0xff21;
        const int GraphicControlExtensionBlockIdentifier = 0xf921;

        const long SourceGlobalColorInfoPosition = 10;
        const long SourceGraphicControlExtensionPosition = 781;
        const long SourceGraphicControlExtensionLength = 8;
        const long SourceImageBlockPosition = 789;
        const long SourceImageBlockHeaderLength = 11;
        const long SourceColorBlockPosition = 13;
        const long SourceColorBlockLength = 768;

        const string ApplicationIdentification = "NETSCAPE2.0";
        const string FileType = "GIF";
        const string FileVersion = "89a";
        #endregion

        class GifFrame
        {
            public GifFrame(Image image, double delay, int xOffset, int yOffset)
            {
                Image = image;
                Delay = delay;
                XOffset = xOffset;
                YOffset = yOffset;
            }

            public Image Image;
            public double Delay;
            public int XOffset, YOffset;
        }

        public GifImage(Stream outStream)
        {
            OutStream = outStream;
            Writer = new BinaryWriter(outStream);
            DefaultFrameDelay = 100;
        }

        #region Properties
        public Stream OutStream { get; }
        private BinaryWriter Writer { get; }

        public int DefaultWidth { get; set; }

        public int DefaultHeight { get; set; }

        public int FrameCount { get; private set; }

        /// <summary>
        /// Default Delay in Milliseconds
        /// </summary>
        public int DefaultFrameDelay { get; set; }

        public int Repeat { get; private set; }
        #endregion

        /// <summary>
        /// Adds a frame to this animation.
        /// </summary>
        /// <param name="image">The image to add</param>
        /// <param name="frameDelay">The delay between frames</param>
        /// <param name="xOffset">The positioning x offset this image should be displayed at.</param>
        /// <param name="yOffset">The positioning y offset this image should be displayed at.</param>
        public void AddFrame(Image image, double? frameDelay = null, int xOffset = 0, int yOffset = 0)
        {
            var frame = new GifFrame(image, frameDelay ?? DefaultFrameDelay, xOffset, yOffset);
            using (var gifStream = new MemoryStream())
            {
                frame.Image.Save(gifStream, ImageFormat.Gif);

                // Steal the global color table info
                if (FrameCount == 0)
                {
                    InitHeader(gifStream, Writer, frame.Image.Width, frame.Image.Height);
                }

                WriteGraphicControlBlock(gifStream, Writer, frame.Delay);
                WriteImageBlock(gifStream, Writer, FrameCount != 0, frame.XOffset, frame.YOffset, frame.Image.Width, frame.Image.Height);
            }
            FrameCount++;
        }

        public void AddFrame(string filePath, double? frameDelay = null, int xOffset = 0, int yOffset = 0)
        {
            AddFrame(new Bitmap(filePath), frameDelay, xOffset, yOffset);
        }

        public void Complete()
        {
            // Complete File
            Writer.Write(FileTrailer);
            Writer.Flush();
        }

        #region Write
        void InitHeader(Stream sourceGif, BinaryWriter Writer, int w, int h)
        {
            // File Header
            Writer.Write(FileType.ToCharArray());
            Writer.Write(FileVersion.ToCharArray());

            Writer.Write((short)(DefaultWidth == 0 ? w : DefaultWidth)); // Initial Logical Width
            Writer.Write((short)(DefaultHeight == 0 ? h : DefaultHeight)); // Initial Logical Height

            sourceGif.Position = SourceGlobalColorInfoPosition;
            Writer.Write((byte)sourceGif.ReadByte()); // Global Color Table Info
            Writer.Write((byte)0); // Background Color Index
            Writer.Write((byte)0); // Pixel aspect ratio
            WriteColorTable(sourceGif, Writer);

            // App Extension Header
            unchecked { Writer.Write((short)ApplicationExtensionBlockIdentifier); };
            Writer.Write((byte)ApplicationBlockSize);
            Writer.Write(ApplicationIdentification.ToCharArray());
            Writer.Write((byte)3); // Application block length
            Writer.Write((byte)1);
            Writer.Write((short)Repeat); // Repeat count for images.
            Writer.Write((byte)0); // terminator
        }

        void WriteColorTable(Stream sourceGif, BinaryWriter writer)
        {
            sourceGif.Position = SourceColorBlockPosition; // Locating the image color table
            var colorTable = new byte[SourceColorBlockLength];
            sourceGif.Read(colorTable, 0, colorTable.Length);
            writer.Write(colorTable, 0, colorTable.Length);
        }

        void WriteGraphicControlBlock(Stream sourceGif, BinaryWriter writer, double frameDelay)
        {
            sourceGif.Position = SourceGraphicControlExtensionPosition; // Locating the source GCE
            var blockhead = new byte[SourceGraphicControlExtensionLength];
            sourceGif.Read(blockhead, 0, blockhead.Length); // Reading source GCE

            unchecked { writer.Write((short)GraphicControlExtensionBlockIdentifier); }; // Identifier
            writer.Write((byte)GraphicControlExtensionBlockSize); // Block Size
            writer.Write((byte)(blockhead[3] & 0xf7 | 0x08)); // Setting disposal flag
            writer.Write((short)(frameDelay / 10)); // Setting frame delay
            writer.Write((byte)blockhead[6]); // Transparent color index
            writer.Write((byte)0); // Terminator
        }

        void WriteImageBlock(Stream sourceGif, BinaryWriter writer, bool includeColorTable, int x, int y, int w, int h)
        {
            sourceGif.Position = SourceImageBlockPosition; // Locating the image block
            var header = new byte[SourceImageBlockHeaderLength];
            sourceGif.Read(header, 0, header.Length);
            writer.Write((byte)header[0]); // Separator
            writer.Write((short)x); // Position X
            writer.Write((short)y); // Position Y
            writer.Write((short)w); // Width
            writer.Write((short)h); // Height

            if (includeColorTable) // If first frame, use global color table - else use local
            {
                sourceGif.Position = SourceGlobalColorInfoPosition;
                writer.Write((byte)(sourceGif.ReadByte() & 0x3f | 0x80)); // Enabling local color table
                WriteColorTable(sourceGif, writer);
            }
            else writer.Write((byte)(header[9] & 0x07 | 0x07)); // Disabling local color table

            writer.Write((byte)header[10]); // LZW Min Code Size

            // Read/Write image data
            sourceGif.Position = SourceImageBlockPosition + SourceImageBlockHeaderLength;

            var dataLength = sourceGif.ReadByte();
            while (dataLength > 0)
            {
                var imgData = new byte[dataLength];
                sourceGif.Read(imgData, 0, dataLength);

                writer.Write((byte)dataLength);
                writer.Write(imgData, 0, dataLength);
                dataLength = sourceGif.ReadByte();
            }

            writer.Write((byte)0); // Terminator
        }
        #endregion

    }
}
