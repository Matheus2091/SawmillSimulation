using SawmillSimulation;
using System.Text;

var initialState = new SawmillState
{
    BendAngle = 4,
    SawTemperature = 18,
    SawSharpening = 100,
    ForkliftFuel = 55,
    FreeStorage = 1498
};

var premises = new SawmillPremises
{
    BendAngleRange = new Range(0, 5),
    GroupingCycleTimeRange = new Range(12, 18),
    TransportCycleTimeRange = new Range(23, 28),
    StorageCycleTimeRange = new Range(14, 23),
    MaximumGroupSize = 50
};

var resultFileContent = new StringBuilder();

var numberOfIterations = 10;

var header = "BendAngle;SawTemperature;SawSharpening;ForkliftFuel;FreeStorage";
resultFileContent.AppendLine(header);

var process = new SawmillProcess(initialState, premises);

for (var i = 0; i < numberOfIterations; i++)
{
    var currentState = process.State;
    var line = $"{currentState.BendAngle};{currentState.SawTemperature};{currentState.SawSharpening};{currentState.ForkliftFuel};{currentState.FreeStorage}";
    resultFileContent.AppendLine(line);

    process.Supply();

    process.Process();

    process.Group();

    if (currentState.GroupSize >= premises.MaximumGroupSize)
    {
        process.Transport();
        process.Store();
    }
}

var solutionPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));
var path = Path.Combine(solutionPath, "result.csv");

File.WriteAllText(path, resultFileContent.ToString());
