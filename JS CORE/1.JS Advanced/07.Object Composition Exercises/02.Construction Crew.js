function constructionCrew(obj) {
    if (obj.handsShaking == false) {
        return obj;
    }
    let requiredAmount = 0.1 * obj.weight * obj.experience;
    obj.handsShaking = false;
    obj.bloodAlcoholLevel += requiredAmount;
    return obj;
}