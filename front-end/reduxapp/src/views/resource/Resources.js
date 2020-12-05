import React, { useEffect } from 'react'  
import { connect } from 'react-redux'  
import { GethResources } from '../../redux/resource/resourcesActions'  
function Resources ({ resourcesData, GethResources }) {  
  useEffect(() => {  
    GethResources()  
  }, [])  
  return resourcesData.loading ? (  
    <h2>Loading</h2>  
  ) : resourcesData.error ? (  
    <h2>{resourcesData.error}</h2>  
  ) : (  
    <div>  
     <div class="row">    
    <div class="col-sm-12 btn btn-info">    
     Teste    
    </div>    
  </div>   
      <div>  
        {resourcesData &&  
          resourcesData.resources &&  
          resourcesData.resources.map(resource => <p>{resource.Email}</p>)}  
      </div>  
      <table class="table" >    
                <thead class="thead-dark">    
                    <tr>    
                        <th scope="col">Id</th>    
                        <th scope="col">Descrição</th>    
                        <th scope="col">Quantidade</th>    
                        <th scope="col">Observação</th>    
                        <th scope="col"> </th>    
                        <th scope="col"> </th>    
                    </tr>    
                </thead>    
                <tbody> 

                    <tr key="1"> 
                        <td>Água</td>    
                        <td>Para matar a sede</td>    
                        <td>32</td>    
                        <td>Teste</td>    
                        <td><button className="btn btn-warning">Editar</button></td>
                        <td><button className="btn btn-danger">Excluir</button></td>   
                    </tr>   
                {/* {
                    resourcesData === null ?
                    null
                :
                resourcesData.resource.map(item => {    
                    return <tr key={item.Id}> 
                        <td>{item.Department}</td>    
                        <td>{item.Description}</td>    
                        <td>{item.Quantity}</td>    
                        <td>{item.Observation}</td>    
                        <td><button className="btn btn-warning">Editar</button></td>
                        <td><button className="btn btn-danger">Excluir</button></td>                             
                    </tr>    
                })}     */}
                </tbody>    
            </table>    
    </div>  
  )  
}  
  
const mapStateToProps = state => {  
  return {  
    resourcesData: state.resources  
  }  
}  
  
const mapDispatchToProps = dispatch => {  
  return {  
    GethResources: () => dispatch(GethResources())  
  }  
}  
  
export default connect(  
  mapStateToProps,  
  mapDispatchToProps  
)(Resources)  