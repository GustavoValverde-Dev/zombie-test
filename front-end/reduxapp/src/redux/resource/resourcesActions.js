import axios from 'axios'  
import {  
  GET_RESOURCES_REQUEST,  
  GET_RESOURCES_SUCCESS,  
  GET_RESOURCES_FAILURE  
} from './resourcesTypes'  
  
export const GethResources = () => {  
  return (dispatch) => {  
    dispatch(getResourcesRequest())  
    axios  
      .get('https://localhost:44317/Api/Student/Getdetaisl')  
      .then(response => {  
        const resources = response.data  
        console.log(response.data);  
        dispatch(getResourcesSuccess(resources))  
      })  
      .catch(error => {  
        dispatch(getResourcesFailure(error.message))  
      })  
  }  
}  
  
export const getResourcesRequest = () => {  
  return {  
    type: GET_RESOURCES_REQUEST  
  }  
}  
  
export const getResourcesSuccess = resources => {  
  return {  
    type: GET_RESOURCES_SUCCESS,  
    payload: resources  
  }  
}  
  
export const getResourcesFailure = error => {  
  return {  
    type: GET_RESOURCES_FAILURE,  
    payload: error  
  }  
}  