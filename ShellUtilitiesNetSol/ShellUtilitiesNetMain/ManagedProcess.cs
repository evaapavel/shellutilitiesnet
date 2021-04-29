using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;



namespace ShellUtilitiesNetMain
{



    /// <summary>
    /// Represents the process to be controlled from within another application.
    /// </summary>
    [GuidAttribute("162a0360-760a-4cf8-b703-04c7f9e629f7")]
    [ComVisible(true)]
    [ProgId("ShellUtilitiesNetMain.ManagedProcess")]
    public class ManagedProcess : IManagedProcess
    {



        /// <summary>Name of the file (with an optional path) to start by calling Start().</summary>
        private string _fileName;

        /// <summary>Command line arguments.</summary>
        private string _arguments;

        /// <summary>Process to control.</summary>
        private Process _process = null;



        ///// <summary>
        ///// Constructor.
        ///// </summary>
        ///// <param name="fileName">Name of the file (with an optional path) to start by calling Start().</param>
        //public ManagedProcess(string fileName)
        //{
        //    _fileName = fileName;
        //    _arguments = null;
        //}



        ///// <summary>
        ///// Constructor.
        ///// </summary>
        ///// <param name="fileName">Name of the file (with an optional path) to start by calling Start().</param>
        ///// <param name="arguments">Command line arguments.</param>
        //public ManagedProcess(string fileName, string arguments)
        //{
        //    _fileName = fileName;
        //    _arguments = arguments;
        //}



        ///// <summary>Name of the file (with an optional path) to start by calling Start().</summary>
        //public string FileName => _fileName;

        ///// <summary>Command line arguments.</summary>
        //public string Arguments => _arguments;



        public string GetFileName()
        {
            return _fileName;
        }
        public void SetFileName(string fileName)
        {
            _fileName = fileName;
        }



        public string GetArguments()
        {
            return _arguments;
        }
        public void SetArguments(string arguments)
        {
            _arguments = arguments;
        }



        /// <summary>
        /// Starts a process using the FileName.
        /// </summary>
        /// <returns>Returns true :-: the process started successfully, false :-: the process did not start for any reason.</returns>
        public bool Start()
        {
            try
            {
                if (_arguments != null)
                {
                    _process = Process.Start(_fileName, _arguments);
                }
                else
                {
                    _process = Process.Start(_fileName);
                }
            }
            //catch (Win32Exception ex)
            catch (Win32Exception)
            {
                return false;
            }
            //catch (FileNotFoundException ex)
            catch (FileNotFoundException)
            {
                return false;
            }
            if (_process == null)
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// Dispose of the associated Process object.
        /// </summary>
        public void Dispose()
        {
            if (_process != null)
            {
                _process.Dispose();
                _process = null;
            }
        }



        /// <summary>
        /// Checks for the state of the associated process.
        /// </summary>
        /// <returns>Returns true :-: the associated process is running, false :-: the process is NOT running for any reason.</returns>
        public bool IsRunning()
        {
            if (_process == null)
            {
                return false;
            }
            if (_process.HasExited)
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// Waits for a specified amount of time for the process to finish.
        /// </summary>
        /// <param name="milliseconds">Time to wait for in milliseconds.</param>
        public void WaitIfRunning(int milliseconds)
        {
            if (_process == null)
            {
                throw new InvalidOperationException($"The process {_fileName} has not started yet.");
            }
            _process.WaitForExit(milliseconds);
        }



    }



}
