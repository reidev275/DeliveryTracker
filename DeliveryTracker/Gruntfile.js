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
			'<%= pkg.name %>.min.js' : [
				'Scripts/lib/jquery-1.9.1.min.js',
				'Scripts/lib/jquery.cookie.js',				
				'Scripts/lib/knockout-2.2.1.js',
				'Scripts/*.js']
		}
      }
    },
	cssmin: {
		compress: {
			files: {
				'<%= pkg.name %>.min.css': [
					'Content/bootstrap.min.css',
					'Content/bootstrap-responsive.min.css',
					'Content/Site.css']
			}
		}
	}
  });

  // Load the plugin that provides the "uglify" task.
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-cssmin');

  // Default task(s).
  grunt.registerTask('default', ['uglify', 'cssmin']);

};