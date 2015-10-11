define(['knockout', 'knockout.validation', 'common'], function (ko) {

    return function teamViewModel() {

        function team(teamId, teamName, logo) {
            this.TeamId = teamId;
            this.TeamName = teamName;
            this.Logo = logo;
        }

        var self = this;

        self.validationEnabled = ko.observable(false);

        // observable arrays are update binding elements upon array changes
        self.teams = ko.observableArray([]);

        self.Id = ko.observable(undefined);
        self.TeamName = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please enter a Team Name' }, minLength: 5, maxLength: 50 });
        self.Logo = ko.observable();

        self.AddEditStatus = ko.observable('Add');

        self.editTeam = function (t) {

            self.Id(t.TeamId);

            var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/' + t.TeamId;

            $.ajax({
                url: url,
                type: 'get',
                contentType: 'application/json',
                success: function (data) {
                    self.TeamName(data.TeamName);
                    self.Logo(data.Logo);
                    self.AddEditStatus('Edit');
                },
                error: function (err) {
                    console.log(err);
                }
            });
        };

        self.updateTeam = function (t) {

            self.validationEnabled(true);
            self.errors = ko.validation.group(self, { deep: true });

            if (self.Id() === undefined) {

                //add
                self.AddEditStatus('Add');

                if (self.errors().length == 0) {

                    var tAdd = new team(self.Id(), self.TeamName(), self.Logo());

                    var dataObjectAdd = ko.toJSON(tAdd);

                    $.ajax({
                        url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/Add',
                        type: 'post',
                        data: dataObjectAdd,
                        contentType: 'application/json',
                        success: function (result) {
                            self.teams.push(new team(result.TeamId, result.TeamName, result.Logo));
                            self.TeamName('');
                            self.Logo('');
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });

                    self.validationEnabled(false);

                } else {
                    self.errors.showAllMessages();
                }
            } else {

                //edit
                self.AddEditStatus('Edit');

                if (self.errors().length == 0) {

                    var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/Update';

                    var tEdit = new team(self.Id(), self.TeamName(), self.Logo());

                    var dataObjectEdit = ko.toJSON(tEdit);

                    $.ajax({
                        url: url,
                        type: 'put',
                        data: dataObjectEdit,
                        contentType: 'application/json',
                        success: function (data) {
                            //remove from array, re-add and sort
                            self.teams.remove(function (item) { return item.TeamId == self.Id(); });
                            self.teams.push(new team(self.Id(), self.TeamName(), self.Logo()));
                            self.teams.sort(function (l, r) { return l.TeamName > r.TeamName ? 1 : -1; });

                            //clear inputs
                            self.Id(undefined);
                            self.TeamName('');
                            self.Logo('');
                            self.AddEditStatus('Add');
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });
                    self.validationEnabled(false);

                } else {
                    self.errors.showAllMessages();
                }
            }
        };

        self.removeTeam = function (t) {

            var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/Delete/' + t.TeamId;

            $.ajax({
                url: url,
                type: 'delete',
                contentType: 'application/json',
                success: function () {
                    self.teams.remove(t);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        };

        self.clearInputFields = function () {

            //clear input fields
            self.TeamName('');
            self.Logo('');
            self.Id(undefined);

            //clear validation messages
            self.TeamName.isModified(false);

            self.AddEditStatus('Add');
        };

        $.ajax({
            url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams',
            type: 'get',
            contentType: 'application/json',
            success: function (data) {
                self.teams.removeAll();
                $.each(data, function (i) {
                    self.teams.push(new team(data[i].TeamId, data[i].TeamName, data[i].Logo));
                });
            },
            error: function (err) {
                console.log(err);
            }
        });
    };
});