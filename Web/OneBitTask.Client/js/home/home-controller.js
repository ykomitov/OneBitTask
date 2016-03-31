(function () {
    'use strict';

    function HomeController($scope, contacts, notifier) {
        var vm = this;
        vm.showModal = false;

        contacts.getAllContacts()
                  .then(function (receivedContacts) {
                      vm.contacts = receivedContacts;
                  });

        vm.delete = function (id) {
            contacts.removeContact(id)
            .then(function (success) {
                notifier.success("Contact deleted!");
            });
        }

        vm.toggleStatus = function (id) {
            contacts.toggleStatus(id)
            .then(function (success) {
                notifier.success("Status changed!");
            });
        }

        vm.update = function (id) {
            vm.showModal = !vm.showModal;
            contacts.getContactById(id)
                    .then(function (contact) {
                        vm.contactToUpdate = contact;
                    });
        }

        vm.closeModal = function () {
            vm.showModal = !vm.showModal;
        }

        vm.updateContact = function (contactToUpdate) {
            contacts.updateContactDetails(contactToUpdate)
                    .then(function (success) {
                        notifier.success("Contact updated!");
                    });
        }
    }

    angular.module('myApp.controllers')
           .controller('HomeController', ['$scope', 'contacts', 'notifier', HomeController]);

}());