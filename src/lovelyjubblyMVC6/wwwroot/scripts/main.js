require(['knockout', 'viewModels/teamViewModel', 'viewModels/fixtureViewModel', 'viewModels/qbratingViewModel', 'domReady!'], function (ko, teamViewModel, fixtureViewModel, qbratingViewModel) {

    //require
    require({
        baseUrl: '/wwwroot',
        paths: {
            text: '/scripts/text'
        }
    });

    //validation
    ko.validation.rules.pattern.message = 'Invalid.';

    ko.validation.init({
        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: true,
        parseInputAttributes: true,
        messageTemplate: null
    });

    //combine multiple view models into master view model as KO is designed for one view model per app
    //and one call to applyBindings
    var masterVM = { team: new teamViewModel(), fixture: new fixtureViewModel(), qbrating: new qbratingViewModel() };

    ko.applyBindingsWithValidation(masterVM);
});