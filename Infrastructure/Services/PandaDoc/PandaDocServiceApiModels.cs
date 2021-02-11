using Newtonsoft.Json;
using System.Collections.Generic;
using Application.Common.Interfaces;
using Application.Common.Models;
using System.Text.Json.Serialization;

namespace Infrastructure.Services.PandaDoc
{
    public partial class PandaDocService
    {
        private class DocumentStatus : BaseSerializableModel<DocumentStatus>
        {
            public string Id { get; set; }
            public string Status { get; set; }
            public string Name { get; set; }
        }

        #region Template

        /**
         * this class represents the structure of the details of a field from the template details
         * {
                "uuid": "PVBn7sLb23iXLBS6oUmZNP",
                "name": "Signature",
                "title": "Signature",
                "assigned_to": {
                    "id": "xccE2Kn2pD3F8kntbBr3FS",
                    "name": "Student",
                    "preassigned_person": null,
                    "type": "role"
                },
                "value": {}
            }
         */
        private class TemplateFieldDetail : BaseSerializableModel<TemplateFieldDetail>
        {
            public string Name { get; set; }
            public string Title { get; set; }
            [JsonPropertyName("assigned_to")]
            public TemplateRole AssignedTo { get; set; }
        }

        /**
         * this class represents the structure of the role a field was assigned to when adding a field to a template
         */
        private class TemplateRole : BaseSerializableModel<TemplateRole>
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        /**
         * this class represents the structure of a template
         * actual response will have more fields and only the fields that currently required are listed
         * {
            "id": "bmevjPUZkAV2cAVwrWs5hN",
            "name": "PandaDoc API Template",
            "fields": [
                {
                    "uuid": "SEfvWdcjDw6iDQUCj4NZZA",
                    "name": "Favorite.Color",
                    "title": "Favorite Color",
                    "assigned_to": {
                        "type": "role",
                        "id": "ni2LQgUeMCwcKN2pFkabU7",
                        "name": "user",
                        "preassigned_person": null
                    },
                    "value": {}
                }
            ],
            "roles": [
                {
                    "id": "ni2LQgUeMCwcKN2pFkabU7",
                    "name": "user",
                    "preassigned_person": null
                }
            ]
        }
         */
        private class TemplateDetails : BaseSerializableModel<TemplateDetails>
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            public string Name { get; set; }
            public List<TemplateFieldDetail> Fields { get; set; }
            public List<TemplateRole> Roles { get; set; }
        }
        #endregion

        #region Document Creation, Sending, Share
        private class Recipient : BaseSerializableModel<Recipient>
        {
            public string Email { get; set; }
            [JsonPropertyName("first_name")]
            public string FirstName { get; set; }
            [JsonPropertyName("last_name")]
            public string LastName { get; set; }
            public string Role { get; set; }
        }

        /**
         * a sample field from PandaDoc API
         *  {
               "title": "Textfield",
               "value": "Ivan Wang"
           }
         */
        private class TemplateField : BaseSerializableModel<TemplateField>
        {
            // the name of the field
            public string Title { get; set; }
            // value of the field. 
            // providing a value, this can be used to prefill the field with name 'title' in the document created from the template
            public string Value { get; set; }
        }

        private class DocumentCreationOptions : BaseSerializableModel<DocumentCreationOptions>
        {


            public string Name { get; set; }
            [JsonPropertyName("template_uuid")]
            public string TemplateUuid { get; set; }
            //public string[] tags { get; set; }
            public List<Recipient> Recipients { get; set; } = new List<Recipient>();

            /**
             * sample fields
             * "fields": {  
                   "Textfield": {
                       "title": "Textfield",
                       "value": "Ivan Wang"
                   }
               }
               Fileds are {key, value} pairs of 'title' and 'TemplateField'
             */
            public Dictionary<string, TemplateField> Fields { get; set; } = new Dictionary<string, TemplateField>();
        }

        private class DocumentCreationResult : BaseSerializableModel<DocumentCreationResult>
        {
            public string Id { get; set; }
            public string Status { get; set; }
            public string Name { get; set; }
            [JsonPropertyName("date_created")]
            public string DateCreated { get; set; }
        }

        private class DocumentSendingOptions : BaseSerializableModel<DocumentSendingOptions>
        {
            public string Message { get; set; }
            public string Subject { get; set; }
            public bool Silent { get; set; }
        }

        private class DocumentSendingResult : BaseSerializableModel<DocumentSendingResult>
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            [JsonPropertyName("expiration_date")]
            public string ExpirationDate { get; set; }
        }

        private class DocumentShareOptions : BaseSerializableModel<DocumentShareOptions>
        {
            public string Recipient { get; set; }
            public int Lifetime { get; set; }
        }

        private class DocumentShareResult : BaseSerializableModel<DocumentShareResult>
        {
            public string Id { get; set; }
            [JsonPropertyName("expires_at")]
            public string ExpiresAt { get; set; }
        }
        #endregion
    }
}