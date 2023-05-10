namespace ProofOfConcepts.LinqTests;

public static class LinqTestsExtensions
{
    public static void Print(this IEnumerable<OutputClass> elements, string indent = "")
    {
        foreach (OutputClass element in elements)
        {
            Console.WriteLine("{0}{1} {2}", indent, element.id, element.text);
            Print(element.children, indent + "  ");
        }
    }

    public static void Unflatten(this List<InputClass> inputList,out List<OutputClass> output)
    {
        var mapping = inputList
        // for each input element, capture the parent id and create the respective output object
        .Select(input => new
        {
            ParentId = input.parentId,
            Obj = new OutputClass() { id = input.id, text = input.text, icon = input.icon, children = new List<OutputClass>() }
        })
        // create a dictionary so we can look up the elements by id
        .ToDictionary(x => x.Obj.id);

        // create target list
        output = new List<OutputClass>();

        // loop through all elements
        foreach (var x in mapping.Values)
        {
            // if the element has a parent id
            if (x.ParentId != 0)
            {
                // find the parent object …
                OutputClass parentObj = mapping[x.ParentId.Value].Obj;
                // … and add this object to the parent’s child list
                parentObj.children.Add(x.Obj);
            }
            else
            {
                // otherwise this is a root element, so add it to the target list
                output.Add(x.Obj);
            }
        }
    }
}