using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRPManagement.DTOs;
using TRPManagement.EF;

namespace TRPManagement.Models
{
    public class ConvertDTO
    {
        public static ChannelDTO Convert(Channel channel)
        {
            return new ChannelDTO
            {
                ChannelId = channel.ChannelId,
                ChannelName = channel.ChannelName,
                EstablishedYear = channel.EstablishedYear,
                Country = channel.Country,
            };
        }
        public static Channel Convert(ChannelDTO channelDTO)
        {
            return new Channel
            {
                ChannelId = channelDTO.ChannelId,
                ChannelName = channelDTO.ChannelName,
                EstablishedYear = channelDTO.EstablishedYear,
                Country = channelDTO.Country,
            };
        }

        public static List<ChannelDTO> Convert(List<Channel> channels)
        {
            var list = new List<ChannelDTO>();
            foreach (var item in channels)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public static ProgramDTO Convert(Program program)
        {
            return new ProgramDTO
            {
                ProgramId = program.ProgramId,
                ProgramName = program.ProgramName,
                TRPScore = program.TRPScore,
                ChannelId = program.ChannelId,
                AirTime = program.AirTime,
            };
        }
        public static Program Convert(ProgramDTO programDTO)
        {
            return new Program
            {
                ProgramId = programDTO.ProgramId,
                ProgramName = programDTO.ProgramName,
                TRPScore = programDTO.TRPScore,
                ChannelId = programDTO.ChannelId,
                AirTime = programDTO.AirTime,
            };
        }

        public static List<ProgramDTO> Convert(List<Program> programs)
        {
            var list = new List<ProgramDTO>();
            foreach (var item in programs)
            {
                list.Add(Convert(item));
            }
            return list;
        }
















    }
}