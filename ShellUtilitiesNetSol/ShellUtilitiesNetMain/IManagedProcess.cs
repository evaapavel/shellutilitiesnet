using System;
using System.Runtime.InteropServices;



namespace ShellUtilitiesNetMain
{



    [GuidAttribute("667DCCA3-17E6-4E3D-94DD-585852D53D84")]
    [ComVisible(true)]
    public interface IManagedProcess
    {



        /// <summary>
        /// Gets the file name to start by Start().
        /// </summary>
        /// <returns>Return the file name.</returns>
        string GetFileName();

        /// <summary>
        /// Sets the file name to start by Start().
        /// </summary>
        /// <param name="fileName">File name.</param>
        void SetFileName(string fileName);



        /// <summary>
        /// Gets the command line arguments.
        /// </summary>
        /// <returns>Returns the command line arguments.</returns>
        string GetArguments();

        /// <summary>
        /// Sets the command line arguments.
        /// </summary>
        /// <param name="arguments">Command line arguments.</param>
        void SetArguments(string arguments);



        /// <summary>
        /// Starts a process using the FileName.
        /// </summary>
        /// <returns>Returns true :-: the process started successfully, false :-: the process did not start for any reason.</returns>
        bool Start();



        /// <summary>
        /// Dispose of the associated Process object.
        /// </summary>
        void Dispose();



        /// <summary>
        /// Checks for the state of the associated process.
        /// </summary>
        /// <returns>Returns true :-: the associated process is running, false :-: the process is NOT running for any reason.</returns>
        bool IsRunning();



        /// <summary>
        /// Waits for a specified amount of time for the process to finish.
        /// </summary>
        /// <param name="milliseconds">Time to wait for in milliseconds.</param>
        void WaitIfRunning(int milliseconds);



    }



}
