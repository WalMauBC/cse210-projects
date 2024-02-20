using System;

class Program
{
    static void Main()
    {
        // Create events
        Event lecture = new Lecture("Lecture Title", "Description of lecture", "2024-02-15", "10:00 AM", new Address("123 Main St", "City", "State", "Country"), "Speaker Name", 50);
        Event reception = new Reception("Reception Title", "Description of reception", "2024-02-20", "6:00 PM", new Address("456 Elm St", "City", "State", "Country"), "example@example.com");
        Event outdoorGathering = new OutdoorGathering("Outdoor Gathering Title", "Description of outdoor gathering", "2024-03-05", "2:00 PM", new Address("789 Oak St", "City", "State", "Country"), "Sunny weather expected");

        // Generate marketing messages
        Console.WriteLine("Marketing Messages:");
        Console.WriteLine("-------------------");
        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}

class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: {GetType().Name}\nTitle: {title}\nDate: {date}";
    }
}

class Lecture : Event
{
    private string speakerName;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speakerName, int capacity) 
        : base(title, description, date, time, address)
    {
        this.speakerName = speakerName;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nSpeaker: {speakerName}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail) 
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherStatement) 
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nWeather: {weatherStatement}";
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state =
