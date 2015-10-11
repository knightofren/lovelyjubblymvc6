/// <binding Clean='clean' ProjectOpened='sasswatch' />

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    project = require("./project.json"),
    sass = require("gulp-sass"),
    ts = require("gulp-typescript");

var paths = {
    webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.sass = paths.webroot + "css/**/*.scss";
paths.sassTarget = paths.webroot + "css/";
paths.typescript = paths.webroot + "js/**/*.ts";
paths.typescriptTarget = paths.webroot + "js/";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

gulp.task('sass', function () {
    gulp.src(paths.sass)
      .pipe(sass().on('error', sass.logError))
      .pipe(gulp.dest(paths.sassTarget));
});

gulp.task('sasswatch', function () {
    gulp.watch(paths.sass, ['sass']);
});

var ts = require('gulp-typescript');

gulp.task('tsCompiler', function () {
    var tsResult = gulp.src(paths.typescript)
      .pipe(ts({
          noImplicitAny: true
      }));
    return tsResult.js.pipe(gulp.dest(paths.typescriptTarget));
});
