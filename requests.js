


function getGroupLessons(id = "79da8ef7-440a-40e2-876e-2f35396afcd4")
{
    fetch("http://shonhodoev.markridge.space/api/schedule/group/"+id, {
        method: "GET"
    })
        .then(response => response.json())
        .then(function(result){
            console.log(result);
        })
}

function setLessons()
{
    fetch("http://shonhodoev.markridge.space/api/schedule/subjects", {
        method: "GET"
    })
        .then(response => response.json())
        .then(function(result){
            setLessonsForSelect(result["subjects"]);
        })
}
