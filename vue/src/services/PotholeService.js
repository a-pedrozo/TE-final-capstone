import axios from 'axios';

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
    }
}