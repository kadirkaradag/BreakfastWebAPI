namespace BreakfastWebAPI.Models
{
    public class BreakfastModel
    {
        public BreakfastModel(
            Guid ıd,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime lastModifiedTime,
            List<string> savory,
            List<string> sweet)
        {
            Id = ıd;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedTime = lastModifiedTime;
            Savory = savory;
            Sweet = sweet;
        }

        public Guid Id { get;  }
        public string Name { get;  }
        public string Description { get;  }
        public DateTime StartDateTime { get;  }
        public DateTime EndDateTime { get;  }
        public DateTime LastModifiedTime { get; }
        public List<string> Savory { get;  }
        public List<string> Sweet { get;  }
    }

   
}
