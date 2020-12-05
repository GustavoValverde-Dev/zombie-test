import { combineReducers } from 'redux'  
import resourcesReducer from './resourcesReducer'  
  
const rootReducer = combineReducers({  
    resources: resourcesReducer  
})  
  
export default rootReducer  