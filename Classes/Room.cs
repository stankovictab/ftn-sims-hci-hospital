/***********************************************************************
 * Module:  Room.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Manager.Room
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class Room
   {
    	public Doctor doctor = null;
   
    	private String RoomNumber;
    	private int FloorNumber;
    	private String Description;
    	private RoomType Type;
    	private RoomStatus Status;

        public string RoomNumber1 { get => RoomNumber; set => RoomNumber = value; }
        public int FloorNumber1 { get => FloorNumber; set => FloorNumber = value; }
        public string Description1 { get => Description; set => Description = value; }
        public RoomType Type1 { get => Type; set => Type = value; }
        public RoomStatus Status1 { get => Status; set => Status = value; }
    
        
		public Room(string roomNumber, int floorNumber, string description, RoomType type, RoomStatus status = RoomStatus.Free)
        {
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
            Description = description;
            Type = type;
            Status = status;
        }

        public Room() { }
    
}