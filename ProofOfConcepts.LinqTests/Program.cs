using ProofOfConcepts.LinqTests;

var inputList = new List<InputClass>();
inputList.Add(new InputClass() { id = 1, text = "Item #1", parentId = 0 });
inputList.Add(new InputClass() { id = 2, text = "Item #2", parentId = 0 });
inputList.Add(new InputClass() { id = 3, text = "Item #3", parentId = 0 });
inputList.Add(new InputClass() { id = 4, text = "SubItem #1", parentId = 1 });
inputList.Add(new InputClass() { id = 5, text = "SubItem #2", parentId = 1 });
inputList.Add(new InputClass() { id = 6, text = "SubItem #3", parentId = 2 });

inputList.Unflatten(out List<OutputClass> outputList);

outputList.Print();
