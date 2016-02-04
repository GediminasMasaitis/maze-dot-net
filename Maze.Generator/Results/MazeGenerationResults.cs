using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze.Generator.Results
{
    public class MazeGenerationResults
    {
        public MazeGenerationResults(GenerationResultsType type)
        {
            Results = new List<MazeGenerationResult>();
            ResultsType = type;
        }

        public IList<MazeGenerationResult> Results { get; }
        public GenerationResultsType ResultsType { get; set; }

        public void Add(MazeGenerationResult generationResult)
        {
            Results.Add(generationResult);
        }

        public static MazeGenerationResults Merge(IEnumerable<MazeGenerationResults> allResults, bool distinct)
        {
            if (allResults == null)
            {
                throw new ArgumentNullException(nameof(allResults));
            }
            var allResultsList = allResults.ToList();
            GenerationResultsType newResultStatus;
            if (allResultsList.Count > 0)
            {
                newResultStatus = allResultsList[allResultsList.Count - 1].ResultsType;
            }
            else
            {
                newResultStatus = GenerationResultsType.Success;
            }
            var newResult = new MazeGenerationResults(newResultStatus);
            var cache = new HashSet<Point>();
            for (var i = allResultsList.Count - 1; i >= 0; i--)
            {
                var results = allResultsList[i];
                foreach (var result in results.Results)
                {
                    if (!distinct || cache.Add(result.Point))
                    {
                        newResult.Results.Add(result);
                    }
                }
            }
            return newResult;
        }
    }
}