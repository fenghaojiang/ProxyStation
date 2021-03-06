﻿using System;
using ProxyStation.Model;
using ProxyStation.Util;

namespace ProxyStation.ProfileParser
{
    public class EncodeOptions
    {
        /// <summary>
        /// Name of the profile to be encoded
        /// </summary>
        /// <value></value>
        public string ProfileName { get; set; }

        /// <summary>
        /// The template to be used to generate a profile
        /// </summary>
        /// <value></value>
        public string Template { get; set; }

        /// <summary>
        /// The downloader used to download file
        /// </summary>
        /// <value></value>
        public IDownloader Downloader { get; set; }
    }

    public interface IProfileParser
    {
        /// <summary>
        /// Parse profile and returns a list of proxy servers
        /// </summary>
        /// <param name="profile">profile content</param>
        /// <returns>a list of servers</returns>
        Server[] Parse(string profile);

        /// <summary>
        /// Combine and format the proxy servers and some snippets to generate a profile for proxy software 
        /// </summary>
        /// <param name="options">encode options</param>
        /// <param name="servers">a list of proxy servers</param>
        /// <param name="encodedServers">a list of encoded proxy servers</param>
        /// <returns>the content of profile</returns>
        string Encode(EncodeOptions options, Server[] servers, out Server[] encodedServers);

        /// <summary>
        /// Return extension name of a profile file
        /// </summary>
        /// <returns>extension name like `.json`</returns>
        string ExtName();
    }

    public class InvalidTemplateException : Exception
    {
    }

    public class ParseException : Exception
    {
        private readonly string reason;
        private readonly string rawURI;

        public ParseException(string reason, string rawURI)
        {
            this.reason = reason;
            this.rawURI = rawURI;
        }
    }
}