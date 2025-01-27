using System;
using System.Collections.Generic;

// Element interface - Agent
public interface IAgent
{
    void Accept(IVisitor visitor);
}

// Agent konkrét osztály
public class Person : IAgent
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitPerson(this);
    }
}

// Visitor interface az Agentekkel való interakciókhoz
public interface IVisitor
{
    void VisitPerson(Person person);
}

// Visitor konkrét implementáció
public class SecurityGuard : IVisitor
{
    public void VisitPerson(Person person)
    {
        Console.WriteLine($"Security Guard: {person.Name}, please show your ID.");
    }
}

// A környezet, ahol Agentek egymással interakcióba lépnek
public class Environment
{
    private List<IAgent> agents = new List<IAgent>();

    public void AddAgent(IAgent agent)
    {
        agents.Add(agent);
    }

    public void InteractWithSecurity(IVisitor visitor)
    {
        foreach (var agent in agents)
        {
            agent.Accept(visitor);
        }
    }
}

// Kliens kód
public class Client
{
    public static void Main(string[] args)
    {
        var environment = new Environment();
        var person1 = new Person("Alice");
        var person2 = new Person("Bob");

        environment.AddAgent(person1);
        environment.AddAgent(person2);

        var securityGuard = new SecurityGuard();
        environment.InteractWithSecurity(securityGuard);
    }
}


/*
A Person osztály implementálja az Agent Interface-t, ezáltal reprezentálja a különböző agenteket a környezetben
Van egy Visitor Interface-ünk, mellyel interaktálhatunk az Agentekkel.
A Szekus implementálja az IVisitor-t
A környezet osztály kezeli az Agent-ek gyájtését és lehetővé teszi az egymás közötti interakciókat Agentek között és Agent-Visitorok között.

A kliens kódban csinálunk oár Person instane-ot és hozzáadjuk őket a környezethez
Ezután létrehozunk egy szekust, akit arra használunk, hogy interaktáljon az agentekkel a környezetben.
*/