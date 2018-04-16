(function() {
  // ===============================================================================
  // Controllers / Main
  //

  function MainCtrl($rootScope) {
    var self = this;

    this.states = [
      { id: 'AK', name: 'Alaska', timezone: 'Alaskan/Hawaiian Time Zone' },
      { id: 'HI', name: 'Hawaii', timezone: 'Alaskan/Hawaiian Time Zone' },
      { id: 'CA', name: 'California', timezone: 'Pacific Time Zone' },
      { id: 'NV', name: 'Nevada', timezone: 'Pacific Time Zone' },
      { id: 'OR', name: 'Oregon', timezone: 'Pacific Time Zone' },
      { id: 'WA', name: 'Washington', timezone: 'Pacific Time Zone' },
      { id: 'AZ', name: 'Arizona', timezone: 'Mountain Time Zone' },
      { id: 'CO', name: 'Colorado', timezone: 'Mountain Time Zone' },
      { id: 'ID', name: 'Idaho', timezone: 'Mountain Time Zone' },
      { id: 'MT', name: 'Montana', timezone: 'Mountain Time Zone' },
      { id: 'NE', name: 'Nebraska', timezone: 'Mountain Time Zone' },
      { id: 'NM', name: 'New Mexico', timezone: 'Mountain Time Zone' },
      { id: 'ND', name: 'North Dakota', timezone: 'Mountain Time Zone' },
      { id: 'UT', name: 'Utah', timezone: 'Mountain Time Zone' },
      { id: 'WY', name: 'Wyoming', timezone: 'Mountain Time Zone' },
      { id: 'AL', name: 'Alabama', timezone: 'Central Time Zone' },
      { id: 'AR', name: 'Arkansas', timezone: 'Central Time Zone' },
      { id: 'IL', name: 'Illinois', timezone: 'Central Time Zone' },
      { id: 'IA', name: 'Iowa', timezone: 'Central Time Zone' },
      { id: 'KS', name: 'Kansas', timezone: 'Central Time Zone' },
      { id: 'KY', name: 'Kentucky', timezone: 'Central Time Zone' },
      { id: 'LA', name: 'Louisiana', timezone: 'Central Time Zone' },
      { id: 'MN', name: 'Minnesota', timezone: 'Central Time Zone' },
      { id: 'MS', name: 'Mississippi', timezone: 'Central Time Zone' },
      { id: 'MO', name: 'Missouri', timezone: 'Central Time Zone' },
      { id: 'OK', name: 'Oklahoma', timezone: 'Central Time Zone' },
      { id: 'SD', name: 'South Dakota', timezone: 'Central Time Zone' },
      { id: 'TX', name: 'Texas', timezone: 'Central Time Zone' },
      { id: 'TN', name: 'Tennessee', timezone: 'Central Time Zone' },
      { id: 'WI', name: 'Wisconsin', timezone: 'Central Time Zone' },
      { id: 'CT', name: 'Connecticut', timezone: 'Eastern Time Zone' },
      { id: 'DE', name: 'Delaware', timezone: 'Eastern Time Zone' },
      { id: 'FL', name: 'Florida', timezone: 'Eastern Time Zone' },
      { id: 'GA', name: 'Georgia', timezone: 'Eastern Time Zone' },
      { id: 'IN', name: 'Indiana', timezone: 'Eastern Time Zone' },
      { id: 'ME', name: 'Maine', timezone: 'Eastern Time Zone' },
      { id: 'MD', name: 'Maryland', timezone: 'Eastern Time Zone' },
      { id: 'MA', name: 'Massachusetts', timezone: 'Eastern Time Zone' },
      { id: 'MI', name: 'Michigan', timezone: 'Eastern Time Zone' },
      { id: 'NH', name: 'New Hampshire', timezone: 'Eastern Time Zone' },
      { id: 'NJ', name: 'New Jersey', timezone: 'Eastern Time Zone' },
      { id: 'NY', name: 'New York', timezone: 'Eastern Time Zone' },
      { id: 'NC', name: 'North Carolina', timezone: 'Eastern Time Zone' },
      { id: 'OH', name: 'Ohio', timezone: 'Eastern Time Zone' },
      { id: 'PA', name: 'Pennsylvania', timezone: 'Eastern Time Zone' },
      { id: 'RI', name: 'Rhode Island', timezone: 'Eastern Time Zone' },
      { id: 'SC', name: 'South Carolina', timezone: 'Eastern Time Zone' },
      { id: 'VT', name: 'Vermont', timezone: 'Eastern Time Zone' },
      { id: 'VA', name: 'Virginia', timezone: 'Eastern Time Zone' },
      { id: 'WV', name: 'West Virginia', timezone: 'Eastern Time Zone' },
    ];

    this.ngTagsInputData = [
      { text: 'Adam Strange' },
      { text: 'Ant-Man' },
      { text: 'Aquaman' },
      { text: 'Barbara Gordon' },
      { text: 'Batman' },
      { text: 'Beast' },
      { text: 'Black Canary' },
      { text: 'Black Lightning' },
      { text: 'Black Panther' },
      { text: 'Black Widow' },
      { text: 'Blade' },
      { text: 'Blue Beetle' },
      { text: 'Booster Gold' },
      { text: 'Bucky Barnes' },
      { text: 'Captain America' },
      { text: 'Captain Britain' },
      { text: 'Captain Marvel' },
      { text: 'Catwoman' },
      { text: 'Cerebus' },
      { text: 'Cyclops' },
      { text: 'Daredevil' },
      { text: 'Dashiell Bad Horse' },
      { text: 'Deadpool' },
      { text: 'Donna Troy' },
      { text: 'Dr. Strange' },
      { text: 'Dream of the Endless' },
      { text: 'Elijah Snow' },
      { text: 'Flash' },
      { text: 'Fone Bone' },
      { text: 'Gambit' },
      { text: 'Ghost Rider' },
      { text: 'Green Arrow' },
      { text: 'Groo' },
      { text: 'Green Lantern' },
      { text: 'Hawkeye' },
      { text: 'Hawkman' },
      { text: 'Hellboy' },
      { text: 'Human Torch' },
      { text: 'Invisible Woman' },
      { text: 'Iron Fist' },
      { text: 'Iron Man' },
      { text: 'James Gordon' },
      { text: 'Jean Grey' },
      { text: 'Jesse Custer' },
      { text: 'John Constantine' },
      { text: 'Jonah Hex' },
      { text: 'Judge Dredd' },
      { text: 'Ka-Zar' },
      { text: 'Kitty Pryde' },
      { text: 'Luke Cage' },
      { text: 'Martian Manhunter' },
      { text: 'Marv' },
      { text: 'Michonne' },
      { text: 'Mitchell Hundred' },
      { text: 'Moon Knight' },
      { text: 'Nick Fury' },
      { text: 'Nightcrawler' },
      { text: 'Nova' },
      { text: 'Professor X' },
      { text: 'Punisher' },
      { text: 'Raphael' },
      { text: 'Reed Richards' },
      { text: 'Renee Montoya' },
      { text: 'Rick Grimes' },
      { text: 'Robin' },
      { text: 'Rorschach' },
      { text: 'Savage Dragon' },
      { text: 'Scott Pilgrim' },
      { text: 'Sgt. Rock' },
      { text: 'She-Hulk' },
      { text: 'Silver Surfer' },
      { text: 'Spawn' },
      { text: 'Spider-Man' },
      { text: 'Spider Jerusalem' },
      { text: 'Storm' },
      { text: 'Sub-Mariner' },
      { text: 'Superboy' },
      { text: 'Supergirl' },
      { text: 'Superman' },
      { text: 'Swamp Thing' },
      { text: 'The Atom' },
      { text: 'The Crow' },
      { text: 'The Falcon' },
      { text: 'The Hulk' },
      { text: 'The Rocketeer' },
      { text: 'The Spectre' },
      { text: 'The Spirit' },
      { text: 'The Thing' },
      { text: 'The Tick' },
      { text: 'Thor' },
      { text: 'Usagi Yojimbo' },
      { text: 'Wasp' },
      { text: 'Wildcat' },
      { text: 'Wolverine' },
      { text: 'Wonder Woman' },
      { text: 'Yorick Brown' },
    ];

    this.ngTagsInputAutocomplete = function($query) {
      $query = ($query || '').toLowerCase();

      return self.ngTagsInputData.reduce(function(result, item) {
        return item.text.toLowerCase().indexOf($query) !== -1 ? result.concat([item]) : result;
      }, []);
    };
  }

  angular.module('pixeladmin')
    .controller('MainCtrl', [ '$rootScope', MainCtrl ]);

})();
