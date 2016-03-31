(function () {
    'use strict';

    function contacts(data) {

        function getAllContacts() {
            return data.get('api/Contacts');
        }

        function getContactById(id) {
            return data.get('api/Contacts/' + id);
        }

        function createContact(contact) {
            return data.post('api/Contacts', contact);
        }

        function removeContact(contactId) {
            return data.deleteContact('api/Contacts/' + contactId);
        }

        function toggleStatus(contactId) {
            return data.put('api/Contacts/' + contactId);
        }

        function updateContactDetails(updatedContact) {
            return data.put('api/Contacts', updatedContact)
        }

        return {
            getAllContacts: getAllContacts,
            getContactById: getContactById,
            createContact: createContact,
            removeContact: removeContact,
            toggleStatus: toggleStatus,
            updateContactDetails: updateContactDetails
        }
    }

    angular.module('myApp.services')
           .factory('contacts', ['data', contacts]);

}());