import * as React from "react";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

interface IState {}

interface IProps {
    is_loading: Boolean;
}

class Spinner extends React.Component<IProps, IState> {
    render() {
        return <div className={'loader' + (!this.props.is_loading ? ' d-none' : '')}>
            <FontAwesomeIcon icon='spinner'/>
        </div>
    }
}

export default Spinner;