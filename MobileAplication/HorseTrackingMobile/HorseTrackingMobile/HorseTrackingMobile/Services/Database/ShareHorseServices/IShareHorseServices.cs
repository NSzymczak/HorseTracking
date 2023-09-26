using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.ShareHorseServices
{
    public interface IShareHorseServices
    {
        void SaveShareFromQR(string horseID, DateTime startDate, DateTime endDate, string userScanID, string userShareID);

        bool CheckShared(string horseID);

        void DelateOutdated();

        bool HasSharedHorses(string userID);

        List<Horse> GetSharedHorses(string userID);

        void CleanShare(string userID);
    }
}