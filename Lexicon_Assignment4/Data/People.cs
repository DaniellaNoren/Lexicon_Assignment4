using Lexicon_Assignment4.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon_Assignment4.Data
{/// <summary>
/// Saves, finds and removes People from Array
/// </summary>
    public class People
    {
        private static Person[] persons = new Person[0];

        /// <summary>
        /// Returns the size of the current Person-Array
        /// </summary>
        /// <returns>Size of Person-Array</returns>
        public int Size()
        {
            return persons.Length;
        }

        /// <summary>
        /// Returns all saved People
        /// </summary>
        /// <returns>Array of People</returns>
        public Person[] FindAll()
        {
            return persons;
        }

        /// <summary>
        /// Finds Person in Array based on id
        /// </summary>
        /// <param name="personId">Id of Person</param>
        /// <returns>Person if id is matching, null if no match is found</returns>
        public Person FindById(int personId)
        {
            foreach(Person person in persons)
            {
                if (person.PersonId == personId)
                    return person;
            }

            return null;
        }

        /// <summary>
        /// Creates, generates Id and saves Person to the Array
        /// </summary>
        /// <param name="firstName">First name of created person</param>
        /// <param name="lastName">Last name of created person</param>
        /// <returns>Created and saved Person, null if parameters are empty or null</returns>
        public Person CreatePerson(string firstName, string lastName)
        {
            Person person;

            try
            {
                person = new Person(PersonSequencer.NextPersonId(), firstName, lastName);
            }
            catch (NullReferenceException)
            {
                return null;
            }

            Array.Resize(ref persons, Size() + 1);
            persons[Size() - 1] = person;

            return person;
        }

        /// <summary>
        /// Resets the People-Array and PersonSequencerId. Removes all saved data
        /// </summary>
        public void Clear()
        {
            persons = new Person[0];
            PersonSequencer.Reset();
        }
    }
}
