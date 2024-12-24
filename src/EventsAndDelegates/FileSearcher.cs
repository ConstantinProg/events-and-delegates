namespace EventsAndDelegates;

public class FileSearcher
{
    public event EventHandler<FileArgs>? FileFound;
    private bool _cancelSearch = false;

    public void SearchFiles(string directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath))
            throw new ArgumentException(nameof(directoryPath), "The directory path cannot be empty");
        if (!Directory.Exists(directoryPath))
            throw new ArgumentException(nameof(directoryPath), "Directory must exist");

        foreach (var file in Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories))
        {
            if (_cancelSearch)
                break;
                        OnFileFound(file);
        }
    }

    protected virtual void OnFileFound(string fileName)
    {
        FileFound?.Invoke(this, new FileArgs(fileName));
    }

    public void StopSearch()
        => _cancelSearch = true;
}
