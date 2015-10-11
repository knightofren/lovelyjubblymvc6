define(['knockout', 'knockout.validation', 'common', 'components'], function (ko) {

    return function fixtureViewModel() {

        function fixture(fixtureId, season, week, homeId, homeName, homeLogo, homeScore, awayId, awayName, awayLogo, awayScore) {
            this.FixtureId = fixtureId;
            this.Season = season;
            this.Week = week;
            this.HomeTeamId = homeId;
            this.HomeTeamName = homeName;
            this.HomeTeamLogo = homeLogo;
            this.HomeTeamScore = homeScore;
            this.AwayTeamId = awayId;
            this.AwayTeamName = awayName;
            this.AwayTeamLogo = awayLogo;
            this.AwayTeamScore = awayScore;
        }

        var self = this;

        self.validationEnabled = ko.observable(false);

        // observable arrays are update binding elements upon array changes
        self.fixtures = ko.observableArray([]);

        self.Id = ko.observable(undefined);
        self.Season = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please select a Season' } });
        self.Week = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please select a Week' } });
        self.AwayTeamId = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please select an Away Team' } });
        self.AwayTeamName = ko.observable();
        self.AwayTeamScore = ko.observable().extend({ min: { params: 0, message: 'Please enter a Score between 0 and 65' }, max: { params: 65, message: 'Please enter a Score between 0 and 65' } });
        self.HomeTeamId = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'Please select a Home Team' } });
        self.HomeTeamName = ko.observable();
        self.HomeTeamScore = ko.observable().extend({ min: { params: 0, message: 'Please enter a Score between 0 and 65' }, max: { params: 65, message: 'Please enter a Score between 0 and 65' } });

        self.selectedSeason = ko.observable();
        self.selectedWeek = ko.observable(); 
        self.selectedAwayTeamId = ko.observable();
        self.selectedHomeTeamId = ko.observable();
        self.selectedAwayTeamName = ko.observable();
        self.selectedHomeTeamName = ko.observable();

        self.AddEditStatus = ko.observable('Add');

        self.editFixture = function (f) {

            self.Id(f.FixtureId);

            //var url = 'http://localhost:5239/api/Fixtures/' + f.FixtureId;
            var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Fixtures/' + f.FixtureId;

            $.ajax({
                url: url,
                type: 'get',
                contentType: 'application/json',
                success: function (data) {
                    self.selectedSeason(data.Season);
                    self.selectedWeek(data.Week);
                    self.selectedAwayTeamId(data.AwayTeamId);
                    self.selectedAwayTeamName(data.AwayTeam.TeamName);
                    self.AwayTeamScore(data.AwayTeamScore);
                    self.selectedHomeTeamId(data.HomeTeamId);
                    self.selectedHomeTeamName(data.HomeTeam.TeamName);
                    self.HomeTeamScore(data.HomeTeamScore);
                    self.AddEditStatus('Edit');
                },
                error: function (err) {
                    console.log(err);
                }
            });
        };

        self.updateFixture = function (t) {

            self.validationEnabled(true);
            self.errors = ko.validation.group(self, { deep: true });

            self.Season(self.selectedSeason());
            self.Week(self.selectedWeek());
            self.HomeTeamId(self.selectedHomeTeamId());
            self.AwayTeamId(self.selectedAwayTeamId());

            if (self.Id() === undefined) {

                //add
                self.AddEditStatus('Add');

                if (self.errors().length == 0) {

                    var fAdd = new fixture(self.Id(), self.Season(), self.Week(), self.HomeTeamId(), 
                        self.HomeTeamName(), '', self.HomeTeamScore(), self.AwayTeamId(), self.AwayTeamName(), '',
                        self.AwayTeamScore());

                    var dataObjectAdd = ko.toJSON(fAdd);

                    $.ajax({
                        //url: 'http://localhost:5239/api/Fixtures/Add',
                        url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Fixtures/Add',
                        type: 'post',
                        data: dataObjectAdd,
                        contentType: 'application/json',
                        success: function (data) {
                            self.fixtures.push(new fixture(data.FixtureId, data.Season, data.Week, data.HomeTeamId,
                                data.HomeTeam.TeamName, '', data.HomeTeamScore, data.AwayTeamId, data.AwayTeam.TeamName, '',
                                data.AwayTeamScore));
                            //clear form
                            self.selectedSeason('');
                            self.selectedWeek('');
                            self.selectedAwayTeamId(undefined);
                            self.selectedAwayTeamName('');
                            self.AwayTeamScore('');
                            self.selectedHomeTeamId(undefined);
                            self.selectedHomeTeamName('');
                            self.HomeTeamScore('');
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

                    //var url = 'http://localhost:5239/api/Fixtures/Update';
                    var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Fixtures/Update';

                    var fEdit = new fixture(self.Id(), self.selectedSeason(), self.selectedWeek(), self.HomeTeamId(),
                        self.HomeTeamName(), '', self.HomeTeamScore(), self.AwayTeamId(), self.AwayTeamName(), '',
                        self.AwayTeamScore());

                    var dataObjectEdit = ko.toJSON(fEdit);

                    $.ajax({
                        url: url,
                        type: 'put',
                        data: dataObjectEdit,
                        contentType: 'application/json',
                        success: function (data) {
                            //remove from array, re-add and sort
                            self.fixtures.remove(function (item) { return item.FixtureId == self.Id(); });
                            self.fixtures.push(new fixture(self.Id(), self.selectedSeason(), self.selectedWeek(),
                                self.HomeTeamId(), data.HomeTeam.TeamName, '', self.HomeTeamScore(),
                                self.AwayTeamId(), data.AwayTeam.TeamName, '', self.AwayTeamScore()));
                            self.fixtures.sort(function (l, r) { return l.FixtureId > r.FixtureId ? 1 : -1; });

                            //clear inputs
                            self.Id(undefined);
                            self.selectedSeason('');
                            self.selectedWeek('');
                            self.selectedAwayTeamId(undefined);
                            self.selectedAwayTeamName('');
                            self.AwayTeamScore('');
                            self.selectedHomeTeamId(undefined);
                            self.selectedHomeTeamName('');
                            self.HomeTeamScore('');
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

        self.removeFixture = function (f) {

            //var url = 'http://localhost:5239/api/Fixtures/Delete/' + f.FixtureId;
            var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/Fixtures/Delete/' + f.FixtureId;

            $.ajax({
                url: url,
                type: 'delete',
                contentType: 'application/json',
                success: function () {
                    self.fixtures.remove(f);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        };

        self.clearInputFields = function () {

            //clear input fields
            self.selectedSeason('');
            self.selectedWeek('');
            self.selectedAwayTeamId(undefined);
            self.selectedAwayTeamName('');
            self.AwayTeamScore('');
            self.selectedHomeTeamId(undefined);
            self.selectedHomeTeamName('');
            self.HomeTeamScore('');
            self.Id(undefined);

            //clear validation messages
            self.Season.isModified(false);
            self.Week.isModified(false);
            self.AwayTeamId.isModified(false);
            self.AwayTeamScore.isModified(false);
            self.HomeTeamId.isModified(false);
            self.HomeTeamScore.isModified(false);
            
            self.AddEditStatus('Add');
        };

        $.ajax({
            //url: 'http://localhost:5239/api/Fixtures',
            url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Fixtures',
            type: 'get',
            contentType: 'application/json',
            success: function (data) {
                self.fixtures.removeAll();
                $.each(data, function (i) {
                    self.fixtures.push(new fixture(data[i].FixtureId, data[i].Season, data[i].Week, data[i].HomeTeamId,
                        data[i].HomeTeam.TeamName, data[i].HomeTeam.Logo, data[i].HomeTeamScore, data[i].AwayTeamId,
                        data[i].AwayTeam.TeamName, data[i].AwayTeam.Logo, data[i].AwayTeamScore));
                });
            },
            error: function (err) {
                console.log(err);
            }
        });
    };
});