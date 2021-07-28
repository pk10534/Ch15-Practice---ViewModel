using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch26_Practice_2___Razor_Forms.Models;

namespace Ch26_Practice_2___Razor_Forms.Data
{
    public class EventData
    {
        //store events
        private static Dictionary<int, Event> Events = new Dictionary<int, Event>(); //store all records of events 

        //add events
        public static void Add(Event passedEvent)
        {
            //Event newEvent = new Event(name, description);
            Events.Add(passedEvent.Id, passedEvent);
        }

        //retrieve events
        public static IEnumerable<Event> GetAll() //holds everything from dict, faster than an array at processing
        {
            return Events.Values; //this is an array of all records in dict. We don't want the keys, we dont want ints, we want thing that are stored as Values
        }

        //retrieve a single event
        public static Event GetById(int Id)
            {
                return Events[Id];
            }

        //remove an event
        public static void Remove(int id)
        {
            Events.Remove(id);
        }


    }
}
