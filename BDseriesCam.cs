using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvaduha.beward
{
    /// <summary>
    /// BD series:
    /// 
    /// root.Brand.*
    /// root.HTTPS.*
    /// root.Image.*
    /// root.Image.I0.Appearance.*
    /// root.Image.I0.Overlay.*
    /// root.Image.I0.ROI.*
    /// root.Image.I0.RateControl.*
    /// root.Image.I0.Text.*
    /// root.ImageSource.I0.Sensor.*
    /// root.Network.*
    /// root.SMTP.*
    /// root.Storage.*
    /// root.Time.*
    /// root.Properties.*
    /// root.Event.*
    /// root.EventServers.*
    /// root.Motion.*
    /// root.NetworkFailure.*
    /// root.Periodical.*
    /// root.Tampering.*
    /// root.Recording.*
    /// root.Schedule.*
    /// root.DDNS.*
    /// root.Framerate.*
    /// root.IR.*
    /// root.NetworkShare.*
    /// root.Profile.*
    /// </summary>
    public class BDseriesCam : BewardCam
    {
        public static class CgiScripts
        {
            public static string Param = "/cgi-bin/admin/param.cgi";
            public static string CamProfileSelect = "/cgi-bin/camctrl_profile.cgi"; // /cgi-bin/camctrl_profile.cgi?num=0
            public static string UserInfo = "/cgi-bin/admin/userinfo.cgi";
            public static string Privacy = "/cgi-bin/admin/privacy.cgi";
            public static string Users = "/cgi-bin/admin/pwdgrp.cgi";
            public static string ImageSnapshot = "/cgi-bin/jpg/image.cgi";
            public static string StorageManagement = "/cgi-bin/admin/storagemanagement.cgi";
            public static string FactoryDefault = "/cgi-bin/admin/factorydefault.cgi";
            public static string HardFactoryDefault = "/cgi-bin/admin/hardfactorydefault.cgi";
            public static string Backup = "/cgi-bin/admin/backup.cgi";
            public static string Restore = "/cgi-bin/admin/restore.cgi";
            public static string BeforeUpgrade = "/cgi-bin/admin/beforeupgrade.cgi";
            public static string FirmwareUpgrade = "/cgi-bin/admin/firmswareupgrade.cgi";
            public static string Restart = "/cgi-bin/admin/restart.cgi";
            public static string ServerReport = "/cgi-bin/admin/serverreport.cgi";
            public static string SystemLog = "/cgi-bin/admin/systemlog.cgi";
            public static string Date = "/cgi-bin/admin/date.cgi";
            public static string Ptz = "/cgi-bin/com/ptz.cgi";
            public static string PtzConfig = "/cgi-bin/com/ptzconfig.cgi";
            public static string Input = "/cgi-bin/io/input.cgi";
            public static string EventData = "/cgi-bin/admin/eventdata.cgi";
        }

        public enum CamCommand
        {
            Brand,
            HTTPS,
            Image,
            ImageIO,
            ImageSource,
            Network,
            SMTP,
            Storage,
            Time,
            Properties,
            Event,
            EventServers,
            Motion,
            NetworkFailure,
            Periodical,
            Tampering,
            Recording,
            Schedule,
            DDNS,
            Framerate,
            IR,
            NetworkShare,
            Profile,
            ProfileSet,
            ImageSnapshot,
        }


        private static Dictionary<CamCommand, RequestTraits> nameRequestMap = new Dictionary<CamCommand, RequestTraits>
        {
            {CamCommand.Brand, new RequestTraits(CgiScripts.Param, "Brand") },
            {CamCommand.HTTPS, new RequestTraits(CgiScripts.Param, "HTTPS") },
            {CamCommand.Image, new RequestTraits(CgiScripts.Param, "Image") },
            {CamCommand.ImageIO, new RequestTraits(CgiScripts.Param, "Image.IO") },
            {CamCommand.ImageSource, new RequestTraits(CgiScripts.Param, "ImageSource") },
            {CamCommand.Network, new RequestTraits(CgiScripts.Param, "Network") },
            {CamCommand.SMTP, new RequestTraits(CgiScripts.Param, "SMTP") },
            {CamCommand.Storage, new RequestTraits(CgiScripts.Param, "Storage") },
            {CamCommand.Time, new RequestTraits(CgiScripts.Param, "Time") },
            {CamCommand.Properties, new RequestTraits(CgiScripts.Param, "Properties") },
            {CamCommand.Event, new RequestTraits(CgiScripts.Param, "Event") },
            {CamCommand.EventServers, new RequestTraits(CgiScripts.Param, "EventServers") },
            {CamCommand.Motion, new RequestTraits(CgiScripts.Param, "Motion") },
            {CamCommand.NetworkFailure, new RequestTraits(CgiScripts.Param, "NetworkFailure") },
            {CamCommand.Periodical, new RequestTraits(CgiScripts.Param, "Periodical") },
            {CamCommand.Tampering, new RequestTraits(CgiScripts.Param, "Tampering") },
            {CamCommand.Recording, new RequestTraits(CgiScripts.Param, "Recording") },
            {CamCommand.Schedule, new RequestTraits(CgiScripts.Param, "Schedule") },
            {CamCommand.DDNS, new RequestTraits(CgiScripts.Param, "DDNS") },
            {CamCommand.Framerate, new RequestTraits(CgiScripts.Param, "Framerate") },
            {CamCommand.IR, new RequestTraits(CgiScripts.Param, "IR") },
            {CamCommand.NetworkShare, new RequestTraits(CgiScripts.Param, "NetworkShare") },
            {CamCommand.Profile, new RequestTraits(CgiScripts.Param, "Profile") },
            {CamCommand.ProfileSet, new RequestTraits(CgiScripts.CamProfileSelect, "") },
            {CamCommand.ImageSnapshot, new RequestTraits(CgiScripts.ImageSnapshot, "") },
        };

        public BDseriesCam(Uri baseUri, string user, string password)
            : base(baseUri, user, password)
        {
        }

        public async Task<string> GetSectionAsync(CamCommand command, string format = OutputFormat.Inf)
        {
            var reqTraits = nameRequestMap[command];
            var uri = new Uri(_baseUri, $"{reqTraits.Script}?action=list&group={reqTraits.Command}");
            Debug.WriteLine(uri);
            var result = await _httpClient.GetAsync(uri);
            var charset = result.Content.Headers.ContentType.CharSet;

            if (charset == Encoding.UTF8.WebName)
                return await result.Content.ReadAsStringAsync();
            else
            {
                var content = await result.Content.ReadAsByteArrayAsync();
                return Convert.ToBase64String(content);
            }
        }

        public async Task<string> SetSectionAsync(CamCommand command, string[] data)
        {
            var reqTraits = nameRequestMap[command];
            var prefixed = data.ToList().Select(x => string.Format("{0}.{1}", reqTraits.Command, x));
            var reqdata = string.Join("&", prefixed);
            var uri = new Uri(_baseUri, $"{reqTraits.Script}?action=update&{reqdata}");
            
            Debug.WriteLine(uri);
            var result = await _httpClient.GetStringAsync(uri);

            return result;
        }

        public override Task<string> GetSectionAsync(string strCommand, string format = OutputFormat.Inf)
        {
            var command = TryParseCommand<CamCommand>(strCommand);
            return GetSectionAsync(command, format);
        }

        public override Task<string> SetSectionAsync(string strCommand, string[] data)
        {
            var command = TryParseCommand<CamCommand>(strCommand);
            return SetSectionAsync(command, data);
        }
    }
}
