using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service;

public static class PathUtil
{
    public static string GetAbsolutePath(string basePath, string relativePath)
    {
        if (Path.IsPathRooted(relativePath))
        {
            return relativePath;
        }
        else
        {
            return Path.GetFullPath(Path.Combine(basePath, relativePath));
        }
    }

    public static string GetRelativePath(string basePath, string fullPath)
    {
        if (fullPath == null) throw new ArgumentNullException(fullPath);
        if (basePath == null) throw new ArgumentNullException(basePath);
        if (Path.IsPathRooted(fullPath) && fullPath.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
        {
            return fullPath.Substring(basePath.Length + 1);
        }
        else
        {
            return fullPath;
        }
    }
}