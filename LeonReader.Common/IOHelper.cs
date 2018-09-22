﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LeonReader.Common
{
    /// <summary>
    /// IO助手
    /// </summary>
    public static class IOHelper
    {

        /// <summary>
        /// 安全的合并路径
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string PathCombine(params string[] paths) => Path.Combine(paths);

        /// <summary>
        /// 返回指定路径字符串的文件名和扩展名
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public static string GetFileName(string FilePath) => Path.GetFileName(FilePath);

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 返回指定路径字符串的文件名（不包括扩展名）
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public static string GetFileNameWithoutExtension(string FilePath) => Path.GetFileNameWithoutExtension(FilePath);

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool FileExists(string path) => File.Exists(path);

        /// <summary>
        /// 获取文件长度
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static long GetFileSize(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new Exception("获取空文件路径的文件大小");
            if (!File.Exists(path)) throw new Exception("无法获取不存在的路径的文件大小");
            else
            {
                try
                {
                    return new FileInfo(path).Length;
                }
                catch (Exception ex)
                {
                    LogHelper.Error($"获取文件大小错误：{ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// 检查目录是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DirectoryExists(string path) => Directory.Exists(path);

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path">目录路径</param>
        public static void CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"IO助手创建目录失败：{path}，{ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 通过流读取图像文件（避免文件占用）
        /// </summary>
        /// <param name="imagePath">图像路径</param>
        /// <returns></returns>
        public static Image ReadeImageByStream(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) throw new Exception("无法通过空路径流读取图像文件的流。");

            try
            {
                using (FileStream ImageStream = new FileStream(imagePath, FileMode.Open))
                {
                    return Image.FromStream(ImageStream);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"通过流读取图像文件失败：{imagePath}，{ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 获取安全文件名（去除文件名非法字符）
        /// </summary>
        /// <returns></returns>
        public static string GetSafeFileName(string filename)
        {
            StringBuilder SafeFileName = new StringBuilder(filename);
            foreach (char InvalidChar in Path.GetInvalidFileNameChars())
                SafeFileName.Replace(InvalidChar.ToString(), string.Empty);
            return SafeFileName.ToString();
        }

        /// <summary>
        /// 获取安全目录名（去除目录名非法字符）
        /// </summary>
        /// <returns></returns>
        public static string GetSafeDirectoryName(string directoryname)
        {
            StringBuilder SafeDirectoryName = new StringBuilder(directoryname);
            foreach (char InvalidChar in Path.GetInvalidPathChars())
                SafeDirectoryName.Replace(InvalidChar.ToString(), string.Empty);
            return SafeDirectoryName.ToString();
        }

    }
}
