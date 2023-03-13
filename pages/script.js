async function getGroups() {
    let groupSelect = document.querySelector("#groupSelect")
    const response = await fetch('http://shonhodoev.markridge.space/api/schedule/groups')
    const obj = await response.json()
    const groups = obj.groups
    let out = `<option value="">Номер группы</option>`
    groups.forEach(group => {
        out += `<option value="${group.id}">${group.number}</option>`
    })
    groupSelect.innerHTML = out
}

async function getTeachers() {
    let teacherSelect = document.querySelector("#teacherSelect")
    const response = await fetch('http://shonhodoev.markridge.space/api/schedule/teachers')
    const obj = await response.json()
    const teachers = obj.teachers
    let out = `<option value="">ФИО преподавателя</option>`
    teachers.forEach(teacher => {
        out += `<option value="${teacher.id}">${teacher.fullName}</option>`
    })
    teacherSelect.innerHTML = out
}

async function getStudyRooms() {
    let studyRoomSelect = document.querySelector("#studyRoomSelect")
    const response = await fetch('http://shonhodoev.markridge.space/api/schedule/audieces')
    const obj = await response.json()
    const studyRooms = obj.audiences
    let out = `<option value="">Номер аудитории</option>`
    studyRooms.forEach(studyRoom => {
        out += `<option value="${studyRoom.id}">${studyRoom.number}</option>`
    })
    studyRoomSelect.innerHTML = out
}