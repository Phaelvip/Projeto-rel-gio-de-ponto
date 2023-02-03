using System;

namespace Dbservice
{
    public class Service
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            _repository = repository;
        }

        public void InsertData(string data)
        {
            _repository.InsertData(data);
        }
    }
}