define('components', ['knockout', 'lodash'], function (ko) {

    ko.components.register('date-dropdowns', {
        viewModel: function (params) {
            this.days = ko.pureComputed(function () {
                var days = [];
                for (var i = 1; i <= 31; i++) {
                    days.push(i);
                }

                var year = this.selectedYear();
                var month = this.selectedMonth();

                if (year && month) {
                    days = _.filter(days, function (day) {
                        var m1 = month - 1;
                        var m2 = new Date(year, m1, day).getMonth();

                        return m1 === m2;
                    });
                }

                return days;

            }, this);
            this.months = ko.observableArray([]);
            this.years = ko.observableArray([]);

            // Add years
            for (var i = 0; i < 120; i++) {
                this.years.push({ name: new Date().getFullYear() - i, id: new Date().getFullYear() - i });
            }
            // Add months
            for (var i = 1; i <= 12; i++) {
                this.months.push({ name: i, id: i });
            }

            var selectedYear = params.selectedYear || ko.observable();
            this.selectedYear = selectedYear;

            var selectedMonth = params.selectedMonth || ko.observable();
            this.selectedMonth = selectedMonth;

            var selectedDay = params.selectedDay || ko.observable();
            this.selectedDay = selectedDay;
        },
        template: { require: 'text!../components/date-dropdowns.html' }
    });

    ko.components.register('hometeam-dropdown', {
        viewModel: function (params) {

            var self = this;
            self.teamNames = ko.observableArray([]);
            // default to a local observable if value not provided
            var selectedHomeTeam = params.value || ko.observable();

            $.ajax({
                //url: 'http://localhost:5239/api/Teams',
                url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams',
                type: 'get',
                contentType: 'application/json',
                success: function (data) {
                    self.teamNames.removeAll();
                    $.each(data, function (i) {
                        self.teamNames.push({ name: data[i].TeamName, id: data[i].TeamId});
                    });
                },
                error: function (err) {
                    console.log(err);
                }
            });

            self.selectedHomeTeam = selectedHomeTeam;
        },
        template: { require: 'text!../components/hometeam-dropdown.html' }
    });

    ko.components.register('awayteam-dropdown', {
        viewModel: function (params) {

            var self = this;
            self.teamNames = ko.observableArray([]);
            // default to a local observable if value not provided
            var selectedAwayTeam = params.value || ko.observable();

            $.ajax({
                //url: 'http://localhost:5239/api/Teams',
                url: 'http://lovelyjubblymvc6.azurewebsites.net/api/Teams',
                type: 'get',
                contentType: 'application/json',
                success: function (data) {
                    self.teamNames.removeAll();
                    $.each(data, function (i) {
                        self.teamNames.push({ name: data[i].TeamName, id: data[i].TeamId });
                    });
                },
                error: function (err) {
                    console.log(err);
                }
            });

            self.selectedAwayTeam = selectedAwayTeam;
        },
        template: { require: 'text!../components/awayteam-dropdown.html' }
    });

    ko.components.register('week-dropdown', {
        viewModel: function (params) {

            var self = this;
            self.weeks = ko.observableArray([]);
            // default to a local observable if value not provided
            var selectedWeek = params.value || ko.observable();

            self.weeks.removeAll();

            for (i = 1; i < 21; i++) { 
                self.weeks.push({ week: i, id: i });
            };

            self.selectedWeek = selectedWeek;
        },
        template: { require: 'text!../components/week-dropdown.html' }
    });

    ko.components.register('season-dropdown', {
        viewModel: function (params) {

            var self = this;
            self.seasons = ko.observableArray([]);
            // default to a local observable if value not provided
            var selectedSeason = params.value || ko.observable();

            self.seasons.removeAll();

            self.seasons.push({ season: 2022, id: 2022 });
            self.seasons.push({ season: 2021, id: 2021 });
            self.seasons.push({ season: 2020, id: 2020 });
            self.seasons.push({ season: 2019, id: 2019 });
            self.seasons.push({ season: 2018, id: 2018 });
            self.seasons.push({ season: 2017, id: 2017 });
            self.seasons.push({ season: 2016, id: 2016 });
            self.seasons.push({ season: 2015, id: 2015 });
            self.seasons.push({ season: 2014, id: 2014 });
            self.seasons.push({ season: 2013, id: 2013 });
            self.seasons.push({ season: 2012, id: 2012 });
            self.seasons.push({ season: 2011, id: 2011 });
            self.seasons.push({ season: 2010, id: 2010 });
            self.seasons.push({ season: 2009, id: 2009 });
            self.seasons.push({ season: 1994, id: 1994 });
            self.seasons.push({ season: 1993, id: 1993 });
            self.seasons.push({ season: 1992, id: 1992 });

            self.selectedSeason = selectedSeason;
        },
        template: { require: 'text!../components/season-dropdown.html' }
    });
});