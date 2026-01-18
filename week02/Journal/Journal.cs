using System.Collections.Generic;

public class Journal
{
    public List<Entry> Entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        Entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in Entries)
        {
            entry.Display();
        }
    }
}
