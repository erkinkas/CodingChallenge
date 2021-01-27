using System;

using Moq;
using Moq.AutoMock;

namespace Tests.Core
{
    public abstract class BaseAutoMock<TSubject>: IDisposable where TSubject: class
    {
        private readonly AutoMocker _mocker;

        private object _subject;

        protected BaseAutoMock()
        {
            _mocker = new AutoMocker();
        }

        protected TSubject ClassUnderTest
        {
            get
            {
                if (_subject != null)
                    return _subject as TSubject;

                _subject = _mocker.CreateInstance<TSubject>();

                return (TSubject) _subject;
            }
        }

        protected Mock<TInterfaceType> GetMock<TInterfaceType>() where TInterfaceType: class
        {
            return _mocker.GetMock<TInterfaceType>();
        }

        public void Dispose()
        {
            _subject = null;
        }
    }
}