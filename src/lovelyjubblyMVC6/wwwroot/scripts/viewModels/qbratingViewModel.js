define(['knockout', 'knockout.validation', 'common', 'components'], function (ko) {

    return function qbratingViewModel() {

        //function team(teamId, teamName, cheerleaderImage, coachImage, divisionId, divisionName, headerImage, logoImage) {
        //    this.TeamId = teamId;
        //    this.TeamName = teamName;
        //    this.CheerleaderImage = cheerleaderImage;
        //    this.CoachImage = coachImage;
        //    this.DivisionId = divisionId;
        //    this.DivisionName = divisionName;
        //    this.HeaderImage = headerImage;
        //    this.LogoImage = logoImage;
        //}

        //var self = this;

        //self.validationEnabled = ko.observable(false);

        //// observable arrays are update binding elements upon array changes
        //self.teams = ko.observableArray([]);

        //self.Id = ko.observable(undefined);
        //self.TeamName = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please enter a Team Name' }, minLength: 5, maxLength: 50 });
        //self.CheerleaderImage = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please enter a Cheerleader Image' }, minLength: 20, maxLength: 100 });
        //self.CoachImage = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please enter a Coach Image' }, minLength: 20, maxLength: 100 });
        //self.DivisionId = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please select a Division' } });
        //self.DivisionName = ko.observable();
        //self.HeaderImage = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please enter a Header Image' }, minLength: 20, maxLength: 100 });
        //self.LogoImage = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please enter a Logo Image' }, minLength: 20, maxLength: 100 });

        //self.selectedDivisionId = ko.observable();
        //self.selectedDivisionName = ko.observable();

        //self.AddEditStatus = ko.observable('Add');

        //self.editTeam = function (t) {

        //    self.Id(t.TeamId);

        //    var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/' + t.TeamId;

        //    $.ajax({
        //        url: url,
        //        type: 'get',
        //        contentType: 'application/json',
        //        success: function (data) {
        //            self.TeamName(data.TeamName);
        //            self.CheerleaderImage(data.CheerleaderImage);
        //            self.CoachImage(data.CoachImage);
        //            self.selectedDivisionId(data.DivisionId);
        //            self.selectedDivisionName(data.Division.DivisionName);
        //            self.HeaderImage(data.HeaderImage);
        //            self.LogoImage(data.LogoImage);
        //            self.AddEditStatus('Edit');
        //        },
        //        error: function (err) {
        //            console.log(err);
        //        }
        //    });
        //};

        //self.updateTeam = function (t) {

        //    self.validationEnabled(true);
        //    self.errors = ko.validation.group(self, { deep: true });

        //    self.DivisionId(self.selectedDivisionId());

        //    if (self.Id() === undefined) {

        //        //add
        //        self.AddEditStatus('Add');

        //        if (self.errors().length == 0) {

        //            var tAdd = new team(self.Id(), self.TeamName(), self.CheerleaderImage(),
        //                                self.CoachImage(), self.DivisionId(),
        //                                self.DivisionName(), self.HeaderImage(),
        //                                self.LogoImage());

        //            var dataObjectAdd = ko.toJSON(tAdd);

        //            $.ajax({
        //                url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/Add',
        //                type: 'post',
        //                data: dataObjectAdd,
        //                contentType: 'application/json',
        //                success: function (result) {
        //                    self.teams.push(new team(result.TeamId, result.TeamName,
        //                                            result.CheerleaderImage, result.CoachImage,
        //                                            result.DivisionId, result.Division.DivisionName,
        //                                            result.HeaderImage, result.LogoImage));
        //                    //case insensitive sorting
        //                    self.teams.sort(function (a, b) {
        //                        if (a.TeamName.toLowerCase() < b.TeamName.toLowerCase()) return -1;
        //                        if (a.TeamName.toLowerCase() > b.TeamName.toLowerCase()) return 1;
        //                        return 0;
        //                    });
        //                    //clear form
        //                    self.TeamName('');
        //                    self.CheerleaderImage('');
        //                    self.CoachImage('');
        //                    self.selectedDivisionId(undefined);
        //                    self.selectedDivisionName('');
        //                    self.HeaderImage('');
        //                    self.LogoImage('');
        //                },
        //                error: function (err) {
        //                    console.log(err);
        //                }
        //            });

        //            self.validationEnabled(false);

        //        } else {
        //            self.errors.showAllMessages();
        //        }
        //    } else {

        //        //edit
        //        self.AddEditStatus('Edit');

        //        if (self.errors().length == 0) {

        //            var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/Update';

        //            var tEdit = new team(self.Id(), self.TeamName(), self.CheerleaderImage(), self.CoachImage(),
        //                                self.DivisionId(), self.DivisionName(),
        //                                self.HeaderImage(), self.LogoImage());

        //            var dataObjectEdit = ko.toJSON(tEdit);

        //            $.ajax({
        //                url: url,
        //                type: 'put',
        //                data: dataObjectEdit,
        //                contentType: 'application/json',
        //                success: function (data) {
        //                    //remove from array, re-add and sort
        //                    self.teams.remove(function (item) { return item.TeamId == self.Id(); });
        //                    self.teams.push(new team(self.Id(), self.TeamName(), self.CheerleaderImage(),
        //                        self.CoachImage(), self.DivisionId(), data.Division.DivisionName,
        //                        self.HeaderImage(), self.LogoImage()));
        //                    //case insensitive sorting
        //                    self.teams.sort(function (a, b) {
        //                        if (a.TeamName.toLowerCase() < b.TeamName.toLowerCase()) return -1;
        //                        if (a.TeamName.toLowerCase() > b.TeamName.toLowerCase()) return 1;
        //                        return 0;
        //                    });

        //                    //clear inputs
        //                    self.Id(undefined);
        //                    self.TeamName('');
        //                    self.CheerleaderImage('');
        //                    self.CoachImage('');
        //                    self.selectedDivisionId(undefined);
        //                    self.selectedDivisionName('');
        //                    self.HeaderImage('');
        //                    self.LogoImage('');
        //                    self.AddEditStatus('Add');
        //                },
        //                error: function (err) {
        //                    console.log(err);
        //                }
        //            });
        //            self.validationEnabled(false);

        //        } else {
        //            self.errors.showAllMessages();
        //        }
        //    }
        //};

        //self.removeTeam = function (t) {

        //    var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams/Delete/' + t.TeamId;

        //    $.ajax({
        //        url: url,
        //        type: 'delete',
        //        contentType: 'application/json',
        //        success: function () {
        //            self.teams.remove(t);
        //        },
        //        error: function (err) {
        //            console.log(err);
        //        }
        //    });
        //};

        //self.clearInputFields = function () {

        //    //clear input fields
        //    self.TeamName('');
        //    self.CheerleaderImage('');
        //    self.CoachImage('');
        //    self.selectedDivisionId(undefined);
        //    self.selectedDivisionName('');
        //    self.HeaderImage('');
        //    self.LogoImage('');
        //    self.Id(undefined);

        //    //clear validation messages
        //    self.TeamName.isModified(false);
        //    self.CheerleaderImage.isModified(false);
        //    self.CoachImage.isModified(false);
        //    self.DivisionId.isModified(false);
        //    self.HeaderImage.isModified(false);
        //    self.LogoImage.isModified(false);

        //    self.AddEditStatus('Add');
        //};

        //$.ajax({
        //    url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams',
        //    type: 'get',
        //    contentType: 'application/json',
        //    success: function (data) {
        //        self.teams.removeAll();
        //        $.each(data, function (i) {
        //            self.teams.push(new team(data[i].TeamId, data[i].TeamName,
        //                                    data[i].CheerleaderImage, data[i].CoachImage,
        //                                    data[i].DivisionId, data[i].Division.DivisionName,
        //                                    data[i].HeaderImage, data[i].LogoImage));
        //        });
        //        //case insensitive sorting
        //        self.teams.sort(function (a, b) {
        //            if (a.TeamName.toLowerCase() < b.TeamName.toLowerCase()) return -1;
        //            if (a.TeamName.toLowerCase() > b.TeamName.toLowerCase()) return 1;
        //            return 0;
        //        });
        //    },
        //    error: function (err) {
        //        console.log(err);
        //    }
        //});
    };
});