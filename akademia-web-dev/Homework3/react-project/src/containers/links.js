import React from 'react';

import Pagination from '../components/Pagination';
import LinksTable from '../components/LinksTable';
import { CFG_HTTP } from '../cfg/cfg_http';
import { UtilsApi } from '../utils/utils_api';

class LinksContainer extends React.Component {
  handlePageChange = (pageNumber) => {
    this.fetchLinks(pageNumber);
  };

  fetchLinks = (currentPage = 1) => {
    let sendData = {page: currentPage};


    UtilsApi
      .get(CFG_HTTP.URL_LINK, sendData)
      .then((link) => {
          this.setState({
              link: link.link,
          pagesLimit: link.page.maxPage,
          currentPage: link.page.currentPage
        });
      });
  };

  componentDidMount() {
    this.fetchLinks();
  }

  constructor() {
    super();

    this.state = {
      link: [],
      pagesLimit: 0,
      currentPage: 1
    };
  }

  render() {
    return (
      <React.Fragment>
        <Pagination currentPage={this.state.currentPage}
                    pagesLimit={this.state.pagesLimit}
                    onPageChange={this.handlePageChange} />
        <LinksTable link={this.state.link} />
      </React.Fragment>
    );
  }
}

export default LinksContainer;
