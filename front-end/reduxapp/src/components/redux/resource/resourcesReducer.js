import {  
    GET_RESOURCES_REQUEST,  
    GET_RESOURCES_SUCCESS,  
    GET_RESOURCES_FAILURE  
  } from './resourcesTypes'  
    
  const initialState = {  
    loading: false,  
    resources: [],  
    error: ''  
  }  
    
  const reducer = (state = initialState, action) => {  
    switch (action.type) {  
      case GET_RESOURCES_REQUEST:  
        return {  
          ...state,  
          loading: true  
        }  
      case GET_RESOURCES_SUCCESS:  
        return {  
          loading: false,  
          resources: action.payload,  
          error: ''  
        }  
      case GET_RESOURCES_FAILURE:  
        return {  
          loading: false,  
          resources: [],  
          error: action.payload  
        }  
      default: return state  
    }  
  }  
    
  export default reducer  