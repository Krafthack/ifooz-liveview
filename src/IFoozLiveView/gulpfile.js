/// <binding BeforeBuild='less' Clean='clean' ProjectOpened='watch' />

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  fs = require("fs");

eval("var project = " + fs.readFileSync("./project.json"));

var paths = {
    root: "./" + project.webroot,
    bower: "./bower_components/",
    stylesheets: "./Assets/Stylesheets/*.less"
};

var destPaths = {
    lib: paths.root + "/lib/",
    stylesheets: paths.root + "/css/"
}

gulp.task("clean", function (cb) {
    rimraf(destPaths.lib, cb);
});

gulp.task("copy", ["clean"], function () {
    var bower = {
        "hammer.js": "hammer.js/hammer*.{js,map}",
        "jquery": "jquery/jquery*.{js,map}",
        "jquery-validation": "jquery-validation/jquery.validate.js",
        "jquery-validation-unobtrusive": "jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
        "fontawesome": "/fontawesome/*/**.{css,otf,eot,svg,ttf,woff,woff2}"

    }

    for (var destinationDir in bower) {
        gulp.src(paths.bower + bower[destinationDir])
          .pipe(gulp.dest(destPaths.lib + destinationDir));
    }
});


//  Less  
var less = require('gulp-less');

gulp.task('less', function () {
    return gulp.src(paths.stylesheets)
      .pipe(less())
      .on('error', swallowError)
      .pipe(gulp.dest(destPaths.stylesheets));
});


// Watch
gulp.task('watch', function() {
    gulp.watch(paths.stylesheets, ['less']);
});



function swallowError(error) {

    console.log(error.toString());

    this.emit('end');
}