﻿ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
		namespace EsimerkkiNamespace
{
		//foreach(var reader in feedReaders
//		GenerateFeedReader
			
		
    public class IltalehtiFeedReaderFeedReader
    {
        public readonly string SourceUrl;
        public readonly int PollFrequencySeconds;
        private RssContent[] PreviousContent;

        public IltalehtiFeedReaderFeedReader(string sourceUrl, int pollFrequencySeconds)
        {
            SourceUrl = sourceUrl;
            PollFrequencySeconds = pollFrequencySeconds;
            initializeEventPoller();
        }

        private void initializeEventPoller()
        {
            // TODO: Poll events with timer

            RssContent[] currentContent= GetCurrentContent();
            foreach (var content in currentContent)
            {
                if(IsNew(content))
                {
                    CallEventsForNew(content);
                }
                if(IsModified(content))
                {
                    CallEventsForModified(content);
                }

            }
            PreviousContent = currentContent;
        }

        private void CallEventsForModified(RssContent content)
        {
			            // TODO:Modified events
        }

        private bool IsModified(RssContent content)
        {
            if (PreviousContent == null)
                return false;
            return PreviousContent.Count(item => item.Title == content.Title && item.Content != content.Content) > 0;
        }

        private void CallEventsForNew(RssContent content)
        {
					EventImplementation.ExecuteModifiedEvent_Oletusmuuttuneet(content);
		            // TODO: New Events
        }

        private bool IsNew(RssContent content)
        {
            if (PreviousContent == null)
                return false;
            return PreviousContent.Count(item => item.Title == content.Title) == 0;
        }

        private RssContent[] GetCurrentContent()
        {
            // TODO: Fetch RSS Content
            return new RssContent[] { new RssContent { Title = "Testititle", Content = "TestiContent"}};
        }
    }

    internal static class EventImplementation
    {
        public static void ExecuteModifiedEvent_Oletusmuuttuneet(RssContent content)
        {
            throw new NotImplementedException();
        }
    }


    public class RssContent
    {
        public string Title;
        public string Content;
    }
}
		
		
		