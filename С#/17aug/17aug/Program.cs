﻿using _17aug;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using System.Xml.Linq;

//XmlWriterExample();
//ReadCarsExample();
//XmlLinqExample();
var doc = StudentXml.GenerateXmlLinq();
StudentXml.PrintStudents(doc);
StudentXml.SearchStudentsGreaterThanAge(doc, 18);
StudentXml.SearchStudentsGreaterThanAge(doc, 20);

static void XmlWriterExample()
{
    var writer = new XmlTextWriter("Cars.xml", Encoding.UTF8);
    writer.Formatting = Formatting.Indented;
    writer.WriteStartDocument();
    writer.WriteStartElement("Cars");

    writer.WriteStartElement("Car");
    writer.WriteStartAttribute("Name");
    writer.WriteString("Lada");
    writer.WriteEndAttribute();
    writer.WriteElementString("Year", "2020");
    writer.WriteElementString("Color", "Black");
    writer.WriteEndElement();

    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Close();
}

static void ReadCarsExample()
{
    var doc = new XmlDocument();
    doc.Load("Cars.xml");

    var cars = FindCarsNode(doc);
    var car = AddChildCar(doc);
    cars.AppendChild(car);

    ReadNode(doc);

    doc.Save("CarsNew.xml");
}

static void ReadNode(XmlNode node)
{
    Console.WriteLine($"{node.NodeType}-{node.Name}-{node.Value}");
    if (!node.HasChildNodes) return;
    foreach (XmlNode childNode in node.ChildNodes)
    {
        ReadNode(childNode);
    }
}

static XmlNode AddChildCar(XmlDocument doc)
{
    XmlElement car = doc.CreateElement("Car", null);
    car.SetAttribute("Name", "Toyota");
    car.AppendChild(CreateElement(doc, "Year", "2002"));
    car.AppendChild(CreateElement(doc, "Color", "White"));
    return car;
}

static XmlNode? FindCarsNode(XmlDocument doc)
{
    foreach(XmlNode child in doc.ChildNodes)
    {
        if (child.Name == "Cars") return child;
    }
    return null;
}

static XmlAttribute CreateAttribute(XmlDocument doc, string attributeName, string value)
{
    XmlAttribute xmlAttribute = doc.CreateAttribute(attributeName);
    xmlAttribute.Value = value;
    return xmlAttribute;
}
static XmlNode CreateElement(XmlDocument doc, string elementName, string value)
{
    var element = doc.CreateElement(elementName);
    element.AppendChild(doc.CreateTextNode(value));
    return element;
}

// Linq XML
void XmlLinqExample()
{
    var cars = new XElement("Cars");
    cars.Add(CreateCar("Lada", "Black", "2020"));
    cars.Add(CreateCar("Toyota", "White", "2019"));
    cars.Add(CreateCar("Lada", "Green", "2020"));


    var document = new XDocument();
    document.Add(cars);
    document.Save("LinqCars.xml");
}

XElement CreateCar(string model, string color, string year)
{
    var car = new XElement("Car");
    car.Add(new XAttribute("Model", model));
    car.Add(new XElement("Color", color));
    car.Add(new XElement("Year", year));
    return car;
}
void SearchXmlLinqExample()
{
    var doc = XDocument.Load("LinqCars.xml");
    var cars = doc.Descendants("Car");
    var filtered = cars.Where(x => x.Element("Year").Value == "2020");
    foreach (var car in filtered)
    {
        Console.WriteLine($"{car.Attribute("Model")}");
    }
}