using System;
using System.Collections.Generic;

public class MemoryMonitor : IDisposable
{
    private long _memoryLimit; 
    private long _warningThreshold;
    private List<byte[]> _allocatedMemory = new List<byte[]>();
    private bool _disposed = false;

    public MemoryMonitor(int memoryLimitMB, int warningPercent = 80)
    {
        _memoryLimit = memoryLimitMB * 1024L * 1024L;
        _warningThreshold = _memoryLimit * warningPercent / 100;
        Console.WriteLine($"Монитор: лимит {memoryLimitMB} МБ, порог {warningPercent}%");
    }

    ~MemoryMonitor()
    {
        Dispose(false);
    }

    public void AllocateMemory(int sizeMB)
    {
        if (_disposed) return;

        long currentUsage = GetCurrentUsage();
        long newSize = sizeMB * 1024L * 1024L;

        if (currentUsage + newSize > _memoryLimit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"КРИТИЧЕСКОЕ ПРЕДУПРЕЖДЕНИЕ: лимит превышен!");
            Console.ResetColor();
            return;
        }

        byte[] data = new byte[newSize];
        _allocatedMemory.Add(data);

        Console.WriteLine($"Выделено {sizeMB} МБ");
        CheckUsage();

        if (_allocatedMemory.Count % 3 == 0)
        {
            Console.WriteLine("Вызов GC.Collect()...");
            GC.Collect();
        }
    }

    public void FreeMemory(int index)
    {
        if (index < _allocatedMemory.Count)
        {
            _allocatedMemory[index] = null;
            _allocatedMemory.RemoveAt(index);
            Console.WriteLine($"Блок {index} освобожден");
            GC.Collect();
            CheckUsage();
        }
    }

    private long GetCurrentUsage()
    {
        long total = 0;
        foreach (var block in _allocatedMemory)
            total += block?.Length ?? 0;
        return total;
    }

    private void CheckUsage()
    {
        long usage = GetCurrentUsage();
        double percent = (double)usage / _memoryLimit * 100;
        Console.WriteLine($"Использовано: {usage / (1024 * 1024)} МБ ({percent:F1}%)");

        if (usage >= _warningThreshold)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"ПРЕДУПРЕЖДЕНИЕ: превышен порог!");
            Console.ResetColor();
        }
    }

    public void ShowGCInfo()
    {
        Console.WriteLine($"\nGC поколение 0: {GC.CollectionCount(0)} сборок");
        Console.WriteLine($"GC поколение 1: {GC.CollectionCount(1)} сборок");
        Console.WriteLine($"GC поколение 2: {GC.CollectionCount(2)} сборок");
        Console.WriteLine($"Память GC: {GC.GetTotalMemory(false) / (1024 * 1024)} МБ\n");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _allocatedMemory?.Clear();
                _allocatedMemory = null;
            }
            _disposed = true;
            Console.WriteLine("Ресурсы освобождены");
        }
    }
}