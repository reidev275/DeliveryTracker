module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),
    uglify: {
      options: {
        banner: '/*! <%= pkg.name %> <%= grunt.template.today("mm-dd-yyyy") %> */\n'
      },
      my_target: {
        files: {
			'DeliveryTracker/<%= pkg.name %>.min.js' : [
				'DeliveryTracker/Scripts/*.js',
				'DeliveryTracker/Scripts/lib/jquery.cookie.js',
				'DeliveryTracker/Scripts/lib/jquery-1.9.1.min.js',
				'DeliveryTracker/Scripts/lib/knockout-2.2.1.js']
		}
      }
    }
  });

  // Load the plugin that provides the "uglify" task.
  grunt.loadNpmTasks('grunt-contrib-uglify');

  // Default task(s).
  grunt.registerTask('default', ['uglify']);

};