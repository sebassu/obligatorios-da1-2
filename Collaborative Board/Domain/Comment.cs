﻿using System;
using Exceptions;

namespace Domain
{
    public class Comment
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new CommentException("El texto introducido para el comentario no es válido, " +
                        "reintente.");
                }
                else
                {
                    text = value;
                }
            }
        }

        private DateTime creationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get { return creationDate; }
        }

        public User Creator { get; private set; }

        public static Comment InstanceForTestingPurposes()
        {
            return new Comment();
        }

        private Comment()
        {
            text = "Comentario inválido.";
        }

        internal static Comment CreatorText(User aUser, string someText)
        {
            return new Comment(aUser, someText);
        }

        private Comment(User aUser, string someText)
        {
            if (Utilities.IsNotNull(aUser))
            {
                SetAttributes(aUser, someText);
            }
            else
            {
                throw new CommentException("Usuario inválido (nulo) recibido.");
            }
        }

        private void SetAttributes(User aUser, string someText)
        {
            Text = someText;
            Creator = aUser;
        }
    }
}
