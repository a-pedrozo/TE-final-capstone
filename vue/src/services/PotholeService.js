import axios from 'axios';

const geoCoderAxios = axios.create({
    baseURL: 'https://api.geoapify.com/v1/geocode'
})


export default{
    getPotholes() {
        return axios.get('pothole');
    },
    deletePothole(potholeId) {
        return axios.delete('pothole/' + potholeId)
    },
    getPothole(potholeId) {
        return axios.get('pothole/' + potholeId)
    },
    reportPothole(newPothole){
        return axios.post('pothole', newPothole);
    },
    reviewPothole(potholeId, pothole) {
        return axios.put('pothole/' + potholeId, pothole)
    },
    unReviewPothole(potholeId) {
        return axios.put('pothole/' + potholeId + '/un')
    },
    scheduleRepair(potholeId, pothole) {
        return axios.put('pothole/' + potholeId + '/re', pothole)
    },
    unScheduleRepair(potholeId) {
        return axios.put('pothole/' + potholeId + '/unre')
    },
    markAsRepaired(potholeId) {
        return axios.put('pothole/' + potholeId + '/repair')
    },
    markAsUnrepaired(potholeId) {
        return axios.put('pothole/' + potholeId + '/unrepair')
    },
    reverseGeoCode(lat, long) {
        return geoCoderAxios.get('/reverse?lat=' + lat + '&lon=' + long + '&apiKey=8200a34491764f28a521fc9873d3e710')
    }
}