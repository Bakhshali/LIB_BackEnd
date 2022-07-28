$(document).ready(function () {

    $(".aboutquiz .box ").click(function () {
        $(".aboutquiz .box").css('background', 'white');
        $(".aboutquiz .box").css('border-top', 'solid 3px #385BCE');
        $(".aboutquiz .boxmidle").css('background', '#F0F4FA');
        $(".aboutquiz .boxmidle").css('border', 'none');
        $(".aboutquiz .boxlaste").css('background', '#F0F4FA');
        $(".aboutquiz .boxlaste").css('border', 'none');
        $(".quizimage").show();
        $(".educationFormat").hide();
        $(".condition").hide();
    });

    $(".aboutquiz .boxmidle ").click(function () {
        $(".aboutquiz .boxmidle").css('background', 'white');
        $(".aboutquiz .boxmidle").css('border-top', 'solid 3px #385BCE');
        $(".aboutquiz .boxlaste").css('background', '#F0F4FA');
        $(".aboutquiz .boxlaste").css('border', 'none');
        $(".aboutquiz .box").css('background', '#F0F4FA');
        $(".aboutquiz .box").css('border', 'none');
        $(".quizimage").hide();
        $(".educationFormat").show();
        $(".condition").hide();
    });

    $(".aboutquiz .boxlaste ").click(function () {
        $(".aboutquiz .boxlaste").css('background', 'white');
        $(".aboutquiz .boxlaste").css('border-top', 'solid 3px #385BCE');
        $(".aboutquiz .boxmidle").css('background', '#F0F4FA');
        $(".aboutquiz .boxmidle").css('border', 'none');
        $(".aboutquiz .box").css('background', '#F0F4FA');
        $(".aboutquiz .box").css('border', 'none');
        $(".quizimage").hide();
        $(".educationFormat").hide();
        $(".condition").show();
    });

    $(".educationFormat").hide();
    $(".condition").hide();


});