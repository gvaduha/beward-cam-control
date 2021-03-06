﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace gvaduha.beward
{
    /// <summary>
    ///SV series
    ///---------
    ///admin.cgi 
    /// get.network.general 
    /// set.network.general 
    /// get.network.advanced 
    /// set.network.advanced 
    /// get.network.ddns
    /// set.network.ddns 
    /// get.network.ipchange (not implemented) 
    /// set.network.ipchange (not implemented) 
    /// get.network.wireless (not implemented) 
    /// set.network.wireless (not implemented) 
    /// search.network.wireless (not implemented) 
    /// get.network.rtsp 
    /// set.network.rtsp
    /// SYSTEM 
    /// get.system.information 
    /// set.system.information 
    /// get.system.datetime 
    /// set.system.datetime 
    /// get.system.maintenance 
    /// reboot.system.maintenance
    /// loaddefault.system.maintenance 
    /// backupfile.system.maintenance (not implemented) 
    /// set system reset
    /// update.cgi
    /// USER
    /// get.system.user
    /// set.system.user
    /// add.system.user
    /// del.system.user
    /// MAINTENANCE
    /// get.auto.reboot
    /// set.auto.reboot
    ///operator.cgi
    /// VIDEO GENERAL 
    /// get.video.general
    /// set.video.general
    /// get.video.resolutions
    /// get.video.bitrates
    /// get.video.parameter
    /// get.fishvideo.general
    /// set.fishvideo.general
    /// get.fishvideo.resolutions
    /// get.fishvideo.bitrates
    /// VIDEO ADVANCED 
    /// get.video.advanced
    /// set.video.advanced
    /// get.fishvideo.advanced
    /// set.fishvideo.advanced
    /// CAMERA SETTINGS 
    /// get.camera.setting
    /// set.camera.setting
    /// set.camera.loaddefault (reset is not implemented, just reboot) 
    /// set.camera.settings.bwmode(not implemented) 
    /// set.camera.settings.maxgain(not implemented) 
    /// get.camera.daynight
    /// set.camera.daynight
    /// get.camera.mask
    /// set.camera.mask
    /// set.camera.setting for BLC
    /// CAMERA PTZ 
    /// get.camera.ptz
    /// set.camera.ptz
    /// STORAGE DISK INFORMATION
    /// get.recordfile.format(not implemented) 
    /// set.recordfile.format(not implemented) 
    /// set.storage.format
    /// record.start
    /// record.stop
    /// record.continue 
    /// get.recyclerecord(deprecated) 
    /// set.recyclerecord(deprecated) 
    /// get.record.status
    /// get.storage.settings
    /// set.storage.settings
    /// get.record.settings
    /// set.record.settings
    /// get.snapshot.settings
    /// set.snapshot.settings
    /// EVENT CONFIGURATION 
    /// get.event.configuration 
    /// update.event.configuration 
    /// add.event.configuration
    /// del.event.configuration
    /// EVENT MOTION DETECTION
    /// get.event.motion.detection
    /// set.motion.osd(not implemented)
    /// update.event.motion.detection
    /// add.event.motion.detection
    /// del.event.motion.detection
    /// EVENT SERVER 
    /// get.event.server
    /// update.event.ftp.server
    /// add.event.ftp.server
    /// del.event.ftp.server
    /// update.event.ftp.server
    /// update.event.http.server
    /// add.event.http.server
    /// del.event.http.server
    /// update.event.tcp.server(not implemented)
    /// add.event.tcp.server(not implemented)
    /// del.event.tcp.server(not implemented)
    /// update.event.smtp.server
    /// add.event.smtp.server
    /// del.event.smtp.server
    /// check.smtp.email
    /// EVENT SERVER I / O
    /// get.event.io
    /// set.event.io
    /// active.event.io
    /// EVENT PIR(not implemented) 
    /// get.event.pir(not implemented)
    /// set.event.pir(not implemented)
    /// YOICS(not implemented)
    /// get.yoics.stat(not implemented)
    /// set.yoics.stat(not implemented)
    /// VCA CONFIGURATION 
    /// get.vca.configuration
    /// set.vca.configuration
    /// VCA DETECTION 
    /// get.vca.regionentrance
    /// set.vca.regionentrance
    /// get.vca.regionexit
    /// set.vca.regionexit
    /// get.vca.advancedmotion
    /// set.vca.advancedmotion
    /// get.vca.tamper
    /// set.vca.tamper
    /// get.vca.alllinecrossing
    /// set.vca.alllinecrossing
    /// get.vca.loitering
    /// set.vca.loitering
    /// get.vca.humandetection
    /// set.vca.humandetection
    /// get.vca.count
    /// set.vca.count
    /// set.vca.cleancount
    /// get.vca.settings
    /// set.vca.settings
    /// get.vca.alarmstatus
    /// get.vca.license
    /// set.vca.license
    /// get.vca.personpoint
    /// download vca counter log 
    /// get.vca.export
    /// set.vca.export
    /// get.vca.leftremove
    /// set.vca.leftremove
    /// Audio
    /// get.audio
    /// set.audio
    /// License Plate Recognition
    /// get.lpr.settings
    /// set.lpr.settings
    /// get.lpr.license
    /// set.lpr.license
    /// add.lprlist.plate
    /// update.lprlist.plate
    /// get.lpr.list
    /// get.lpr.log
    /// get.lprblack.settings
    /// set.lprblack.settings
    /// get.lprwhite.settings
    /// set.lprwhite.settings
    /// get.lprvisitor.settings
    /// set.lprvisitor.settings
    /// download lpr list
    /// download lpr logs
    /// upload lpr list
    /// Face Detection 
    /// get.face.configuration
    /// set.face.configuration
    /// White LED 
    /// get.manualwled.settings
    /// set.manualwled.settings
    /// get.whiteled.status
    /// set.whiteled.status
    /// Area Cropping
    /// get.croproi.enable
    /// set.croproi.enable
    /// get.croproi.settings
    /// set.croproi.settings
    ///viewer.cgi
    /// Live view 
    /// get.liveview
    /// rotate.dptz(not implemented)
    /// get.fishmount
    /// set.fishmount
    /// get.fishdisplay
    /// set.fishdisplay
    /// get.fishcorrect
    /// set.fishcorrect
    /// PTZ control 
    /// ptz.control
    /// ptz.speed
    /// fishptz.control
    /// ptz.status
    /// System
    /// get.setup
    /// get.Model
    /// get.model.general
    ///Operator misc
    /// filelist.cgi
    /// file.list
    /// del.files(not implemented)
    /// playback(not implemented)
    /// recycle.cgi(not implemented)
    /// Snapshot
    ///Misc CGI
    /// notify.fcgi
    /// set.notify
    /// audio.fcgi
    /// </summary>
    public class SVseriesCam : BewardCam
    {
        public static class CgiScripts
        {
            public static string Admin = "/cgi-bin/admin/admin.cgi";
            public static string Operator = "/cgi-bin/operator/operator.cgi";
            public static string CamProfile = "/cgi-bin/camctrl_profile.cgi";
            public static string Update = "/update.cgi";
            public static string Viewer = "/cgi-bin/viewer/viewer.cgi";
            public static string FileList = "/cgi-bin/operator/filelist.cgi";
            public static string Recycle = "/cgi-bin/operator/recycle.cgi";
            public static string DataLoader = "/dataloader.cgi";
            public static string Notify = "/cgi-bin/notify.fcgi";
            public static string Audio = "/cgi-bin/audio.fcgi";
            public static string ImageSnapshotTi = "/cgi-bin/admin/snapshot.cgi"; // Ti
            public static string ImageSnapshotMSxC = "/snapshot.cgi"; // MSAC, MSHC
        }

        public enum CamCommand
        {
            NetworkGeneral,
            NetworkAdvanced,
            NetworkDDNS,
            NetworkIpChange,
            NetworkWireless,
            NetworkRtsp,
            SystemInfo,
            SystemDatetime,
            SystemMaintenance,
            SystemUser,
            VideoGeneral,
            VideoBitrates,
            VideoResolutions,
            VideoParam,
            FishVideoGeneral,
            FishVideoResolutions,
            FishVideoBitrates,
            VideoAdvanced,
            FishVideoAdvanced,
            CameraSetting,
            CameraDaynight,
            CameraBwMode,
            CameraMaxGain,
            CameraMask,
            CameraPtz,
            RecordFileFormat,
            StorageFormat,
            ImageSnapshotTi,
            ImageSnapshotMSxC,
        }

        private static Dictionary<CamCommand, RequestTraits> nameRequestMap = new Dictionary<CamCommand, RequestTraits>
        {
            {CamCommand.NetworkGeneral, new RequestTraits(CgiScripts.Admin, "network.general") },
            {CamCommand.NetworkAdvanced, new RequestTraits(CgiScripts.Admin, "network.advanced") },
            {CamCommand.NetworkDDNS, new RequestTraits(CgiScripts.Admin, "network.ddns") },
            {CamCommand.NetworkIpChange, new RequestTraits(CgiScripts.Admin, "network.ipchange") },
            {CamCommand.NetworkWireless, new RequestTraits(CgiScripts.Admin, "network.wireless") },
            {CamCommand.NetworkRtsp, new RequestTraits(CgiScripts.Admin, "network.rtsp") },
            {CamCommand.SystemInfo, new RequestTraits(CgiScripts.Admin, "system.information") },
            {CamCommand.SystemDatetime, new RequestTraits(CgiScripts.Admin, "system.datetime") },
            {CamCommand.SystemUser, new RequestTraits(CgiScripts.Admin, "system.user") },
            {CamCommand.VideoGeneral, new RequestTraits(CgiScripts.Operator, "video.general") },
            {CamCommand.VideoResolutions, new RequestTraits(CgiScripts.Operator, "video.resolutions") },
            {CamCommand.VideoBitrates, new RequestTraits(CgiScripts.Operator, "video.bitrates") },
            {CamCommand.VideoParam, new RequestTraits(CgiScripts.Operator, "video.parameter") },
            {CamCommand.VideoAdvanced, new RequestTraits(CgiScripts.Operator, "video.advanced") },
            {CamCommand.FishVideoGeneral, new RequestTraits(CgiScripts.Operator, "fishvideo.general") },
            {CamCommand.FishVideoResolutions, new RequestTraits(CgiScripts.Operator, "fishvideo.resolutions") },
            {CamCommand.FishVideoBitrates, new RequestTraits(CgiScripts.Operator, "fishvideo.bitrates") },
            {CamCommand.FishVideoAdvanced, new RequestTraits(CgiScripts.Operator, "fishvideo.advanced") },
            {CamCommand.CameraSetting, new RequestTraits(CgiScripts.Operator, "camera.setting") },
            {CamCommand.CameraBwMode, new RequestTraits(CgiScripts.Operator, "camera.settings.bwmode") },
            {CamCommand.CameraMaxGain, new RequestTraits(CgiScripts.Operator, "camera.settings.maxgain") },
            {CamCommand.CameraDaynight, new RequestTraits(CgiScripts.Operator, "camera.daynight") },
            {CamCommand.CameraMask, new RequestTraits(CgiScripts.Operator, "camera.mask") },
            {CamCommand.ImageSnapshotTi, new RequestTraits(CgiScripts.ImageSnapshotTi, "") },
            {CamCommand.ImageSnapshotMSxC, new RequestTraits(CgiScripts.ImageSnapshotMSxC, "") },
        };

        public SVseriesCam(Uri baseUri, string user, string password)
            : base(baseUri, user, password)
        {}

        public async Task<string> GetSectionAsync(CamCommand command, string format = OutputFormat.Inf)
        {
            var reqTraits = nameRequestMap[command];
            var uri = new Uri(_baseUri, $"{reqTraits.Script}?action=get.{reqTraits.Command}&format={format}");
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
            var reqdata = string.Join("&", data);
            var reqTraits = nameRequestMap[command];
            var uri = new Uri(_baseUri, $"{reqTraits.Script}?action=set.{reqTraits.Command}&{reqdata}");
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
