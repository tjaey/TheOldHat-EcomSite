using System;
using System.Numerics;

namespace TheOldHat.Domain
{
    public class Product : IEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Count { get; private set; }

        public Product(int id, string name, int count, string description)
        {
            if(id < 0)
            {
                throw new ArgumentException("id");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name");
            }

            Id = id;
            Name = name;
            Count = count;

            if (string.IsNullOrWhiteSpace(description))
            {
                Description = "";
            }
            else
            {
                Description = description;
            }
        }

        public void ChangeId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id");
            }
            Id = id;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name");
            }

            Name = name;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("description");
            }

            Description = description;
        }

        public void ChangeCount(int count)
        {
            Count = count;
        }

    }

}
