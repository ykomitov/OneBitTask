(function () {
    'use strict';

    function CreateContactController(contacts, notifier) {
        var vm = this;
        
        vm.saveNewContact = function (contact) {
            contacts.createContact(contact)
                    .then(function (success) {
                        if (success) {
                            notifier.success('Contact saved!');
                        }
                    });
        }
    }

    angular.module('myApp.controllers')
           .controller('CreateContactController', ['contacts', 'notifier', CreateContactController]);

}());