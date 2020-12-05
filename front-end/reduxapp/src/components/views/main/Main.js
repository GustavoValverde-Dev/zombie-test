import React from 'react'
import { connect } from 'react-redux'
import { Button, } from 'reactstrap'
function Main() {
    return (
        <div>
            <div className="row">
                <div className="col-sm-12 btn btn-info">
                    Sistema para administração de recursos

                    <button className="btn btn-danger">teste bootstrap</button>
                </div>
            </div>
        </div>
    )
}

const mapStateToProps = state => {
    return {
        main: state.main
    }
}

export default connect(
    mapStateToProps,
)(Main)  