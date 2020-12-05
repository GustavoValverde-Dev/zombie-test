import React, { useEffect } from 'react'
import { connect } from 'react-redux'
function Main() {
    return (
        <div>
            <div class="row">
                <div class="col-sm-12 btn btn-info">
                    Sistema para administração de recursos
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